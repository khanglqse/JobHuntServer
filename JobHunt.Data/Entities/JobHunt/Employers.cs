using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.JobHunt
{
    [Serializable]
    [Table("Employers")]
    public class Employers : EntityBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public List<Job> Jobs { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public int OpenPosition { get; set; }
        public int ViewCount { get; set; }
        public string LogoImage { get; set; }
        public int LongDescription { get; set; }
        public int Followers { get; set; }
        public Contact Contact { get; set; }
        
    }
}