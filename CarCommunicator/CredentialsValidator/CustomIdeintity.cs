using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.CredentialsValidator
{
    public class CustomIdeintity : IIdentity
    {
        private string _authenticationType;
        private bool _isAuthenticated;
        private string _name;

        public string AuthenticationType
        {
            get { return _authenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        public string Name
        {
            get { return _name; }
        }

        public CustomIdeintity(string authType, bool iAuth, string name)
        {
            this._authenticationType = authType;
            this._isAuthenticated = iAuth;
            this._name = name;
        }

    }
}
