using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Serialization.Newtonsoft
{
    public class JsonSerializationService : ISerializationService
    {
        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public async Task<string> SerializeAsync<T>(T message)
        {
            return await Task.FromResult(JsonConvert.SerializeObject(message, _jsonSerializerSettings));
        }

        public async Task<T> DeserializeAsync<T>(string message, NamingStrategy namingStrategy = NamingStrategy.SnakeCase)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            if (namingStrategy == NamingStrategy.SnakeCase)
            {
                jsonSerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            }

            return await Task.FromResult(JsonConvert.DeserializeObject<T>(message, jsonSerializerSettings));
        }
    }
}
