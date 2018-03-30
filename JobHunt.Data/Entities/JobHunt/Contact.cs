using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.JobHunt
{
    [Serializable]
    [Table("Contact")]
    public class Contact : EntityBase
    {
        public string FacebookLink { get; set; }
        public string TwitchLink { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployerSiteUrl { get; set; }
        public string ContactPoint { get; set; }
        public string Office { get; set; }
    }
}