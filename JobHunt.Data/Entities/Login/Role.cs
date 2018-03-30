using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.Login
{
    [Serializable]
    [Table("Role")]
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}