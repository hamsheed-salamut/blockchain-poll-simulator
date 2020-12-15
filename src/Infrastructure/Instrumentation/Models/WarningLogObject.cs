using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Instrumentation.Models
{
    public class WarningLogObject
    {
        public string Message { get; }
        public Dictionary<string, object> AdditionalLogs { get; set; }
        public Exception Exception { get; }

        //public ErrorLogObject(string message)
        //{
        //    Message = message;
        //    AdditionalLogs = new Dictionary<string, object>();
        //    Exception = new Exception(message);
        //}

        //public ErrorLogObject(string message, Dictionary<string, object> additionalLogs, Exception exception = null)
        //{
        //    Message = message;
        //    AdditionalLogs = additionalLogs;
        //    Exception = exception ?? new Exception(message);
        //}

        //public ErrorLogObject(Exception exception, string message)
        //{
        //    Message = message;
        //    AdditionalLogs = new Dictionary<string, object>();
        //    Exception = exception;
        //}

        public void AddAdditionalLog(string property, object value)
        {
            AdditionalLogs.Add(property, value);
        }
    }
}
