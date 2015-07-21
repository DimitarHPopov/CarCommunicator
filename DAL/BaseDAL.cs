using CarCommunicator.Common.Data;
using CarCommunicator.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.DAL
{
    public class BaseDAL : IDisposable
    {
        private Common.Logger.Logger _logingActions;
        private ReuqestMaker _maker;

        public BaseDAL(ReuqestMaker maker)
        {
            this._maker = maker;

            _logingActions = new Logger(_maker.User, Common.LogType.Create, "Call Constructor");
        }

        protected void Log(string message)
        {
            _logingActions.SetMessage(message, Common.LogType.Message);
        }

        protected void Exception(string message)
        {
            _logingActions.SetMessage(message, Common.LogType.Exception);
        }

        public void Dispose()
        {
            _logingActions.SetMessage("Call Destructor", Common.LogType.Destroy);
        }

        ~BaseDAL()
        {
            Dispose();
            SaveLogger();
        }

        private void SaveLogger()
        {
            try
            {
                using(var context = new CarCommunicator.Common.Data.CarCommunicatorEntities())
                {
                    LoggerBase logger = new LoggerBase();
                    logger.User = this._maker.User;
                    logger.Guid = this._logingActions.ReuqestGuid.ToString();

                    context.LoggerBase.Add(logger);

                    foreach(var ac in _logingActions.GetActions)
                    {
                        LoggerInformation info = new LoggerInformation();
                        info.LoggerBase = logger;
                        info.Message = ac.Message;
                        info.MessageType = (int)ac.Type;
                        info.ActionDate = ac.LocalTime;

                        context.LoggerInformation.Add(info);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
