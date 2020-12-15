using Infrastructure.Instrumentation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Instrumentation
{
    public interface ILoggingService
    {
        void LogError(ErrorLogObject errorLogObject);
        void LogWarning(string warningMessage);
        void LogWarning(WarningLogObject warningLogObject);
        void LogInfo(InfoLogObject infoLogObject);
    }
}
