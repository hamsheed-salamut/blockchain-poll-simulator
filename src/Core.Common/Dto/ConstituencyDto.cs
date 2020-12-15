using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Dto
{
    public class ConstituencyDto
    {
        public long ConstituencyId { get; set; }
        public List<CandidateDto> Candidates { get; set; }
        public ConstituencyDto()
        {
            Candidates = new List<CandidateDto>();
        }
    }
}
