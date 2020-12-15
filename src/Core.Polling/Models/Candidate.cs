using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Polling.Models
{
    public class Candidate
    {
        public long CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateParty { get; set; }
        public long CandidatePartyId { get; set; }
    }
}
