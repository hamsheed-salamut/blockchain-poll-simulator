using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Core.Common.Entities
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
        [ValidateNever]
        public string Hash { get; set; }
        [NotMapped]
        public bool IsValid { get; set; }
        public virtual VotesEntry Previous { get; set; }
    }
}
