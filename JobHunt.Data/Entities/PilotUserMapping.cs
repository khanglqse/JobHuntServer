using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iKPORT.Data.Entity
{
    [Table("PilotUserMapping")]
    public class PilotUserMapping
    {
        [Key]
        public int Id { get; set; }

        public int? PilotId { get; set; }

        public int? UserId { get; set; }

        public bool IsDelete { get; set; }

        public DateTime? InsAt { get; set; }

        public string InsBy { get; set; }

        public DateTime? UpdAt { get; set; }

        public string UpdBy { get; set; }
    }
}
