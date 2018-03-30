using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.Email
{
    [Serializable]
    [Table("EmailTemplate")]
    public class EmailTemplate : EntityBase
    {
        public string TemplateName { get; set; }
        public string ToList { get; set; }
        public string From { get; set; }
        public string CCList { get; set; }
        public string BCCList { get; set; }
        public string Subject { get; set; }
        public string TemplateBody { get; set; }
    }
}