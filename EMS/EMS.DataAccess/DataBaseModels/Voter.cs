using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.DataAccess.DataBaseModels
{
    public partial class Voter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aadhar { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
