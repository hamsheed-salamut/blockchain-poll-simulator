using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Serialization
{
    public interface ISerializationService
    {
        Task<string> SerializeAsync<T>(T message);
        Task<T> DeserializeAsync<T>(string message, NamingStrategy namingStrategy = NamingStrategy.SnakeCase);
    }
}
