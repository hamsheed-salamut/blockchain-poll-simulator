using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Entities
{
    public class Voter
    {
        public long VoterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public DateTime DateBirth { get; set; }
        public string NIC { get; set; }
        public long ConstituencyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
