using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccess.DataBaseModels
{
    public class Constituency
    {
        public int Id { get; set; }
        public string ConstituencyName { get; set; }
        public string State { get; set; }
        public string CurrentMember { get; set; }
    }
}
