using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESC.Admin.Models
{
    public class Constituency
    {
        public long ConstituencyId { get; set; }
        public string ConstituencyName { get; set; }
        public long ElectoralPopulation { get; set; }
        public string EthnicMajority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
