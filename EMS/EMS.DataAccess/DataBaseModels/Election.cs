using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.DataAccess.DataBaseModels
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
