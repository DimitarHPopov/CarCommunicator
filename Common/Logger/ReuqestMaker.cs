using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.Common.Logger
{
    public class ReuqestMaker
    {
        public string User { get; set; }
        public string MethodName { get; set; }

        public ReuqestMaker(string user)
        {
            this.User = user;
        }
    }
}
