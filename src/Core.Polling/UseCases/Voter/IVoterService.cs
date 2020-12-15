using Core.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polling.UseCases.Voter
{
    public interface IVoterService
    {
        Task<VoterDto> Authenticate(string nic);

    }
}
