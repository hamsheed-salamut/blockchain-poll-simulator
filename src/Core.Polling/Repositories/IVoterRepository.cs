using Core.Common.Dto;
using Core.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Polling.Repositories
{
    public interface IVoterRepository
    {
        Task<Voter> GetVoterByNic(string nic);
    }
}
