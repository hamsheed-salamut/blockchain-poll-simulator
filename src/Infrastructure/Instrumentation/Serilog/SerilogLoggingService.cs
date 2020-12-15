using Infrastructure.Instrumentation.Models;
using Infrastructure.Serialization.Newtonsoft;
using Serilog;
using Serilog.Core.Enrichers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Instrumentation.Serilog
{
    public class SerilogLoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public SerilogLoggingService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogError(ErrorLogObject errorLogObject)
        {
            var additionalLogs = errorLogObject.AdditionalLogs;
            if (additionalLogs != null && additionalLogs.Any())
            {
                var serializer = new JsonSerializationService();
                var propertyEnrichers = new List<PropertyEnricher>();

                foreach (var property in additionalLogs)
                {
                    if (property.Value == null) continue;
                    var propertyType = property.Value.GetType();

                    if (propertyType.IsPrimitive)
                    {
                        propertyEnrichers.Add(new PropertyEnricher(property.Key, property.Value));
                    }
                    else
                    {
                        var jsonData = serializer.SerializeAsync(property.Value).GetAwaiter().GetResult();
                        propertyEnrichers.Add(new PropertyEnricher(property.Key, jsonData));
                    }
                }

                _logger
                    .ForContext(propertyEnrichers)
                    .Error(errorLogObject.Exception, errorLogObject.Message);
            }
            else
            {
                _logger.Error(errorLogObject.Exception, errorLogObject.Message);
            }
        }

        public void LogWarning(string warningMessage)
        {
            _logger.Warning(warningMessage);
        }

        public void LogWarning(WarningLogObject warningLogObject)
        {
            var additionalLogs = warningLogObject.AdditionalLogs;
            if (additionalLogs != null && additionalLogs.Any())
            {
                var serializer = new JsonSerializationService();
                var propertyEnrichers = new List<PropertyEnricher>();

                foreach (var property in additionalLogs)
                {
                    if (property.Value == null) continue;
                    var propertyType = property.Value.GetType();

                    if (propertyType.IsPrimitive)
                    {
                        propertyEnrichers.Add(new PropertyEnricher(property.Key, property.Value));
                    }
                    else
                    {
                        var jsonData = serializer.SerializeAsync(property.Value).GetAwaiter().GetResult();
                        propertyEnrichers.Add(new PropertyEnricher(property.Key, jsonData));
                    }
                }

                _logger
                    .ForContext(propertyEnrichers)
                    .Warning(warningLogObject.Message);
            }
            else
            {
                _logger.Warning(warningLogObject.Message);
            }
        }

        public void LogInfo(InfoLogObject infoLogObject)
        {
            var additionalLogs = infoLogObject.AdditionalLogs;
            if (additionalLogs != null && additionalLogs.Any())
            {
                var serializer = new JsonSerializationService();
                var propertyEnrichers = new List<PropertyEnricher>();

                foreach (var property in additionalLogs)
                {
                    if (property.Value == null) continue;
                    var propertyType = property.Value.GetType();

                    if (propertyType.IsPrimitive)
                    {
                        propertyEnrichers.Add(new PropertyEnricher(property.Key, property.Value));
                    }
                    else
                    {
                        var jsonData = serializer.SerializeAsync(property.Value).GetAwaiter().GetResult();
                        propertyEnrichers.Add(new PropertyEnricher(property.Key, jsonData));
                    }
                }

                _logger
                    .ForContext(propertyEnrichers)
                    .Information(infoLogObject.Message);
            }
            else
            {
                _logger.Information(infoLogObject.Message);
            }
        }
    }
}
