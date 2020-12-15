using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Blockchain.Models
{
    public class VotesEntry
    {
        [Key]
        public long Id { get; set; }
        public long VoteEntryId { get; set; }
        public long? PreviousId { get; set; }
        public long CandidateId { get; set; }
        public string CandidateName { get; set; }
        public long PartyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Hash { get; set; }
        public bool IsValid { get; set; }
        public virtual VotesEntry Previous { get; set; }
    }
}
