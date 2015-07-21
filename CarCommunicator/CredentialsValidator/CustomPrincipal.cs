using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.CredentialsValidator
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity _identity;
        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public CustomPrincipal(IIdentity identity)
        {
            _identity = identity;
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
