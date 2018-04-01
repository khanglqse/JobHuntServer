using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JobHunt.Data.Entities.JobHunt;

namespace JobHunt.Data.Entities.Login
{
    [Serializable]
    [Table("User")]
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Platform { get; set; }
        public string ContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public ICollection<Employer> Employers { get; set; }
    }
}