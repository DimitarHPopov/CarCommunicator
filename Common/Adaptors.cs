using CarCommunicator.Common.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.Common
{
    public static class Adaptors
    {
        public static Common.ServiceData.CarInfo WcfCarInfo(Common.Data.CarInformation sqlInfo)
        {
            if(sqlInfo == null)
            {
                return null;
            }

            CarInfo wcfInfo = new CarInfo();

            wcfInfo.Brand = sqlInfo.Brand;
            wcfInfo.Id = sqlInfo.ID;
            wcfInfo.Information = sqlInfo.Information;
            wcfInfo.Model = sqlInfo.Model;
            wcfInfo.Owner = sqlInfo.Owner;

            var lastData = sqlInfo.CarData.Where(c => c.Lat.HasValue).OrderByDescending(t => t.ReceiveDate).FirstOrDefault();

            if(lastData != null)
            {
            wcfInfo.LastKnownPosition = new Position()
            {
                Lat = lastData.Lat.Value,
                Lng = lastData.Lng.Value,
                PositionTime = lastData.ReceiveDate
            };
            }

            return wcfInfo;
        }

        public static Common.ServiceData.CarInfo WcfCarInfo(Common.Data.CarData sqlInfo)
        {
            if (sqlInfo == null)
            {
                return null;
            }

            CarInfo wcfInfo = new CarInfo();

            wcfInfo.Brand = sqlInfo.CarInformation.Brand;
            wcfInfo.Id = sqlInfo.CarInformation.ID;
            wcfInfo.Information = sqlInfo.CarInformation.Information;
            wcfInfo.Model = sqlInfo.CarInformation.Model;
            wcfInfo.Owner = sqlInfo.CarInformation.Owner;

            wcfInfo.LastKnownPosition = new Position()
            {
                Lat = sqlInfo.Lat.Value,
                Lng = sqlInfo.Lng.Value,
                PositionTime = sqlInfo.ReceiveDate
            };

            return wcfInfo;
        }
    }
}
