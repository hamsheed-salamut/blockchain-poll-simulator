using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Entities
{
    public class Vote
    {
        public long VoteId { get; set; }
        public long ElectionId { get; set; }
        public long CandidateId { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string CandidateAka { get; set; }
        public string VoterId { get; set; }
        public long PartyId { get; set; }
        public long ConstituencyId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
