using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsValidator
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException("You must provide both the username and password to access this service");
            }

            if (!(userName == "dpopov" && password == "dpopov123456Aa"))
            {
                throw new System.ServiceModel.FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}
