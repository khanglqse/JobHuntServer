using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.Login
{
    [Serializable]
    [Table("User")]
    public class User : EntityBase
    {
        public string Domain { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string Division { get; set; }
        public string ContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string StaffNumber { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}