using CarCommunicator.Common.Data;
using CarCommunicator.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.DAL
{
    public class CarDatas : BaseDAL
    {
        public CarDatas(ReuqestMaker maker)
            : base(maker)
        {

        }

        public string InsertData(DateTime date, double lat, double lng, int carId, float battery)
        {
            try
            {
                base.Log("Inser Data");

                using(var context = new CarCommunicatorEntities())
                {
                    CarData data = new CarData();

                    data.Lat = lat;
                    data.Lng = lng;
                    data.ReceiveDate = date;
                    data.CarInformationId = carId;
                    data.BatteryPercent = battery;

                    context.CarData.Add(data);

                    context.SaveChanges();

                    return "Success added information";
                }
            }
            catch(Exception ex)
            {
                base.Exception(ex.Message);

                return ex.Message;
            }
        }

        public CarCommunicator.Common.ServiceData.CarInfo GetCarInformation(int id)
        {
            try
            {
                base.Log("GetCarInformation");

                using (var context = new CarCommunicatorEntities())
                {
                    var carInfo = (from c in context.CarData
                                   where c.CarInformation.ID == id
                                         &&
                                         c.Lat.HasValue 
                                         &&
                                         c.Lng.HasValue
                                   orderby c.ReceiveDate descending
                                   select c).FirstOrDefault();


                    return Common.Adaptors.WcfCarInfo(carInfo);

                }
            }
            catch (Exception ex)
            {
                base.Exception(ex.Message);

                return null;
            }
        }
    }
}
