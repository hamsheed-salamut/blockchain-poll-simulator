using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Entities
{
    public class Candidate
    {
        public long CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aka { get; set; }
        public string EthnicGroup { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public long PartyId { get; set; }
        public long ElectionId { get; set; }
        public long ConstituencyId { get; set; }
    }
}
