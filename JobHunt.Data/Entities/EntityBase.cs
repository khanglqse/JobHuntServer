using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }

        public DateTime InsAt { get; set; }

        public string InsBy { get; set; }

        public DateTime UpdAt { get; set; }

        public string UpdBy { get; set; }
    }
}
