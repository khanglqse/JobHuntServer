using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.JobHunt
{
    [Serializable]
    [Table("Job")]
    public class Job : EntityBase
    {
        public string Type { get; set; }
        public string Position { get; set; }
        public string RequiredSkill { get; set; }
        public string Salary { get; set; }
    }
}