using System;
using System.ComponentModel.DataAnnotations;

namespace JobHunt.Services.Models.Email
{
    [Serializable]
    public class EmailTemplateModel : BaseModel
    {
        [Required]
        public string TemplateName { get; set; }

        public string ToList { get; set; }

        public string From { get; set; }

        public string CCList { get; set; }

        public string BCCList { get; set; }

        [Required]
        public string Subject { get; set; }

        public string TemplateBody { get; set; }

        public string Status { get; set; }
    }
}