using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace CarCommunicator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    public interface IRestService
    {
        Common.Logger.ReuqestMaker Requester { get; set; }

        [WebGet]
        string ReceiveCarData(string carId, DateTime date, double lat, double lng, float battery);
    }
}
