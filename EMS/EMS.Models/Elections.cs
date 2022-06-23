using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public partial class Election
    {
        public int Id { get; set; }
        public string Candidate { get; set; }
        public string Party { get; set; }
        public string Constituency { get; set; }
        public string Symbol { get; set; }
        public int Votes { get; set; }
    }
}
