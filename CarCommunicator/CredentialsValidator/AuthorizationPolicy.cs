using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarCommunicator.CredentialsValidator
{
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        string id = Guid.NewGuid().ToString();

        public string Id
        {
            get { return this.id; }
        }

        public System.IdentityModel.Claims.ClaimSet Issuer
        {
            get { return System.IdentityModel.Claims.ClaimSet.System; }
        }

        // this method gets called after the authentication stage
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            string authHeader = ctx.IncomingRequest.Headers[HttpRequestHeader.Authorization];

            if(!string.IsNullOrEmpty(authHeader))
            {
                string decryptedAuth = Common.Utils.Decrypt(authHeader.Substring(5).Trim());

                if (!string.IsNullOrEmpty(decryptedAuth) && decryptedAuth.Split('|').Length == 2 && decryptedAuth.Split('|')[0] == "mitko" && decryptedAuth.Split('|')[1] == "!@#mitko123")
                {
                    evaluationContext.Properties["Principal"] = new CustomPrincipal(new CredentialsValidator.CustomIdeintity("Basic", true, "decryptedAuth[0]"));

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }
        }
    }
}
