using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.Common.Logger
{
    public class Logger
    {
        public string User { get; set; }

        public Guid ReuqestGuid { get; set; }

        protected List<LogingActions> Actions;

        public List<LogingActions> GetActions
        {
            get
            {
                return Actions;
            }
        }

        public Logger()
        {
            Actions = new List<LogingActions>();
        }

        public Logger(string user)
            : this()
        {
            this.User = user;
            this.ReuqestGuid = Guid.NewGuid();
        }

        public Logger(string user, LogType type, string message)
            : this()
        {
            this.User = user;
            this.ReuqestGuid = Guid.NewGuid();

            SetMessage(message, type);
        }

        public void SetMessage(string message, LogType messageType)
        {
            this.Actions.Add(new LogingActions(message, messageType));
        }
    }
}
