using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Instrumentation.Models
{
    public class InfoLogObject
    {
        public string Message { get; }
        public Dictionary<string, object> AdditionalLogs { get; set; }

        public InfoLogObject(string message)
        {
            Message = message;
            AdditionalLogs = new Dictionary<string, object>();
        }

        public InfoLogObject(string message, Dictionary<string, object> additionalLogs)
        {
            Message = message;
            AdditionalLogs = additionalLogs;
        }

        public void AddAdditionalLog(string property, object value)
        {
            AdditionalLogs.Add(property, value);
        }
    }
}
