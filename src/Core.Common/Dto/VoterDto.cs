using System.Collections.Generic;
using System.Text;

namespace Core.Common.Dto
{
    public class VoterDto
    {
        public long VoterId { get; set; }
        public string Nic { get; set; }
        public long ConstituencyId { get; set; }
        public List<CandidateDto> Candidates { get; set; }
        public VoterDto()
        {
            Candidates = new List<CandidateDto>();
        }
    }
}
