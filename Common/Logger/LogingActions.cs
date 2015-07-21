using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.Common.Logger
{
    public class LogingActions
    {
        private DateTime _actionTime;

        public DateTime LocalTime
        {
            get
            {
                return _actionTime;
            }
        }

        public string Message { get; set; }

        public LogType Type { get; set; }

        public LogingActions(string message, LogType type)
        {
            this.Message = message;
            this.Type = type;
            this._actionTime = DateTime.Now;
        }
    }
}
