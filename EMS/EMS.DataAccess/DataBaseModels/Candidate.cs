using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.DataAccess.DataBaseModels
{
    public partial class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public string Constituency { get; set; }
        public string Address { get; set; }
    }
}
