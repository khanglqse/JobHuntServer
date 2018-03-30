using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.Attachment
{
    [Serializable]
    [Table("Attachment")]
    public class Attachment : EntityBase
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public string IncidentTitle { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
    }
}