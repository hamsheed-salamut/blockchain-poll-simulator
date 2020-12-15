using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Mssql.Options
{
    public class MsSqlDbOptions
    {
        public string ConnectionString { get; set; }
        public string IntergrationConnectionString { get; set; }
        public string TppVisaConnectionString { get; set; }
        public int TimeoutValue { get; set; }
        public string IntegrationCipherKey { get; set; }
        public string Mode { get; set; }
    }
}
