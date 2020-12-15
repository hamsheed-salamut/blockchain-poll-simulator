using Core.Common.Entities;
using Core.Polling.Models;
using Dapper;
using Infrastructure.Persistence.Mssql;
using Infrastructure.Persistence.Mssql.Options;
using Serilog;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Dto;
using System;

namespace Core.Polling.Repositories
{
    public class VoterRepository : BaseRepository<Voter>, IVoterRepository
    {
        public VoterRepository(MsSqlDbOptions msSqlDbOptions) : base(msSqlDbOptions)
        {
              
        }

        public async Task<Voter> GetVoterByNic(string nic)
        {
            try
            {
                string query = @"SELECT VoterId, ConstituencyId
                                FROM dbo.Voter
                             WHERE NIC = @nicParam";

                var result = await Connection.QueryAsync<Voter>(query,
                                    new { nicParam = nic }, commandTimeout: 300);

                var voterObj = result.FirstOrDefault();

                return voterObj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
