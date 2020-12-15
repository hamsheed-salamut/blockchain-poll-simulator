using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Dto
{
    public class VotesDto
    {
        public long CandidateId { get; set; }
        public string CandidateName { get; set; }
        public long? PartyId { get; set; }
    }
}
