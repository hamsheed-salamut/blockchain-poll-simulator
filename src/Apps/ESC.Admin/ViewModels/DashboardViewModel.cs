using ESC.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESC.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public List<Constituency> Constituencies { get; set; }
        public long RegisteredVotersCount { get; set; }

        public DashboardViewModel()
        {
            Constituencies = new List<Constituency>();
        }
    }
}
