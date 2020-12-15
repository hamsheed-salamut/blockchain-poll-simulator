using Infrastructure.Persistence.Mssql.Options;
using Infrastructure.Resilience.Polly;
using Serilog;
using SimpleStack.Orm;
using SimpleStack.Orm.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Mssql
{
    public abstract class BaseRepository<T> : IDisposable
    {
        protected readonly ILogger _logger;
        private readonly MsSqlDbOptions _msSqlDbOptions;

        protected OrmConnection Connection { get; set; }

        public BaseRepository(
            MsSqlDbOptions msSqlDbOptions)
        {
            _msSqlDbOptions = msSqlDbOptions;

            try
            {
                Connect();
            }
            catch (Exception e)
            {
               // logger.Error(e, "Connection to the database has failed");
            }
        }

        private void Connect()
        {
            PollyRetryRegistry.GetPolicy(5, 2, "InitiateMySqlConnection", _logger)
                                   .Execute(() => {
                                       var factory = new OrmConnectionFactory(new SqlServerDialectProvider(), _msSqlDbOptions.ConnectionString);
                                       Connection = factory.OpenConnection();
                                   });
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                await Connection.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"* Record could not be updated into the database due to the following exception: *", ex);
            }
        }

        public async Task AddAsync(params T[] entities)
        {
            try
            {
                await Connection.InsertAsync<T>(entities);
            }
            catch (Exception ex)
            {
                throw new Exception($"* Records could not be inserted into the database due to the following exception: *", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Connection.SelectAsync<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"* Records could not be fetched into the database due to the following exception: *", ex);
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
