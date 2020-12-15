using Core.Common.Dto;
using Infrastructure.Blockchain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polling.Repositories
{
    public interface IPollingRepository
    {
        Task<List<CandidateDto>> GetCandidatesListForConstituency(long constituencyId);
        Task CastVotes(VotesEntry votesEntry);
    }
}
