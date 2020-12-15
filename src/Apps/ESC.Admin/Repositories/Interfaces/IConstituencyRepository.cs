using ESC.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESC.Admin.Repositories.Interfaces
{
    public interface IConstituencyRepository
    {
        Task<List<Constituency>> GetConstituencies();
    }
}
