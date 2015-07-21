using CarCommunicator.CredentialsValidator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace CarCommunicator
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode =
        AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [SecurityBehavior] 
    public class RestService
    {
        public Common.Logger.ReuqestMaker Requester
        {
            get
            {
                return new Common.Logger.ReuqestMaker("webservice");
            }
            set
            {
                
            }
        }

        [WebGet]
        [PrincipalPermission(SecurityAction.Demand, Role = "ADMIN")]
        public string ReceiveCarData(string carId, DateTime date, double lat, double lng, float battery)
        {
            return new BL.CarDatas.CarDatas(this.Requester).InsertData(date, lat, lng, int.Parse(carId), battery);
        }

        [WebGet]
        public Common.ServiceData.CarInfo CarInformation(int id)
        {
            return new BL.CarDatas.CarDatas(this.Requester).GetCarInformation(id);
        }

    }
}
