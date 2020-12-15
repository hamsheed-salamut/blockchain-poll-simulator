using Core.Common.Dto;
using Core.Polling.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polling.UseCases.Voter
{
    public class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;
        private readonly ILogger _logger;

        public VoterService(
            IVoterRepository voterRepository
         )
        {
            _voterRepository = voterRepository;
           // _logger = logger;
        }

        public async Task<VoterDto> Authenticate(string nic)
        {
            var voterDto = new VoterDto();

            try
            {
                var voter = await _voterRepository.GetVoterByNic(nic);

                if (voter != null)
                {
                    voterDto.VoterId = voter.VoterId;
                    voterDto.ConstituencyId = voter.ConstituencyId;
                    voterDto.Nic = voter.NIC;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"An error occured {ex.Message}"); 
                throw;                
            }

            return voterDto;
        }
    }
}
