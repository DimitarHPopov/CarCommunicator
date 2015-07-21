using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.BL.CarDatas
{
    public class CarDatas
    {
        private Common.Logger.ReuqestMaker maker;
        private DAL.CarDatas dalDatas;

        public CarDatas(Common.Logger.ReuqestMaker maker)
        {
            this.maker = maker;
            dalDatas = new DAL.CarDatas(maker);
        }

        public string InsertData(DateTime date, double lat, double lng, int carId, float battery)
        {
            return  dalDatas.InsertData(date, lat, lng, carId, battery);
        }

        public CarCommunicator.Common.ServiceData.CarInfo GetCarInformation(int id)
        {
            return dalDatas.GetCarInformation(id);
        }
    }
}
