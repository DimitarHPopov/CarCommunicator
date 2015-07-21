using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.CredentialsValidator
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SecurityBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new AuthorizationPolicy());
            serviceHostBase.Authorization.ExternalAuthorizationPolicies =
                            policies.AsReadOnly();

            ServiceAuthorizationBehavior bh =
                serviceDescription.Behaviors.Find<ServiceAuthorizationBehavior>();
            if (bh != null)
            {
                bh.PrincipalPermissionMode = PrincipalPermissionMode.Custom;
            }
            else
                throw new NotSupportedException();
        }

        public void AddBindingParameters(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase,
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }

        public void Validate(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase) { }
    }
}
