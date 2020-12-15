using Core.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Polling.UseCases.Constituency
{
    public interface IConstituencyService
    {
        Task<ConstituencyDto> GetCandidatesListForConstituency(long constituencyId);
    }
}
