using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.JobHunt
{
    [Serializable]
    [Table("Address")]
    public class Address : EntityBase
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    
    }
}