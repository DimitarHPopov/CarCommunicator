//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarCommunicator.Common.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoggerBase
    {
        public LoggerBase()
        {
            this.LoggerInformation = new HashSet<LoggerInformation>();
        }
    
        public int ID { get; set; }
        public string Guid { get; set; }
        public string User { get; set; }
    
        public virtual ICollection<LoggerInformation> LoggerInformation { get; set; }
    }
}
