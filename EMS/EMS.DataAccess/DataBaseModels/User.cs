using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.DataAccess.DataBaseModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
