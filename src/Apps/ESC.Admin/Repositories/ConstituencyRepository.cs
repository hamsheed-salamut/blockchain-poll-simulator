using ESC.Admin.Models;
using ESC.Admin.Repositories.Interfaces;
using Infrastructure.Persistence.Mssql;
using Infrastructure.Persistence.Mssql.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESC.Admin.Repositories
{
    public class ConstituencyRepository : BaseRepository<Constituency>, IConstituencyRepository
    {
        public ConstituencyRepository(MsSqlDbOptions msSqlDbOptions) : base(msSqlDbOptions)
        {

        }

        public async Task<List<Constituency>> GetConstituencies()
        {
            var constituencies = await GetAllAsync();
            
            return constituencies.ToList();
        }
    }
}
