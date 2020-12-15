using Core.Common.Dto;
using Core.Polling.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polling.UseCases.Constituency
{
    public class ConstituencyService : IConstituencyService
    {
        private readonly IPollingRepository _pollingRespository; 

        public ConstituencyService(
            IPollingRepository pollingRepository)
        {
            _pollingRespository = pollingRepository;
        }

        public async Task<ConstituencyDto> GetCandidatesListForConstituency(long constituencyId)
        {
            try
            {
                var constituencyDto = new ConstituencyDto();
                //   _logger.Information($"Fetching list of candidates for constituency {voter.ConstituencyId} for Voter Id {voterDto.VoterId} at {DateTime.Now}");

                var candidateListForVoter = await _pollingRespository.GetCandidatesListForConstituency(constituencyId);

                //   _logger.Information($"{candidateListForVoter.Count} candidates found for constituency {voter.ConstituencyId}");

                foreach (var candidate in candidateListForVoter)
                {
                    constituencyDto.Candidates.Add(candidate);
                }

                return constituencyDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
