using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Dto
{
    public class CandidateDto
    {
        public long CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aka { get; set; }
        public string EthnicGroup { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public long PartyId { get; set; }
        public string PartyName { get; set; }
        public string PartyAbbr { get; set; }
        public string PartyEmblem { get; set; }
        public string ActualAlliance { get; set; }
        public long ElectionId { get; set; }
        public long ConstituencyId { get; set; }
        public string ElectionName { get; set; }
        public string ConstituencyName { get; set; }
    }
}
