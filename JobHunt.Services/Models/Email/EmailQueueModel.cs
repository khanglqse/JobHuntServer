using System;
using System.ComponentModel.DataAnnotations;

namespace JobHunt.Services.Models.Email
{
    [Serializable]
    public class EmailQueueModel : BaseModel
    {
        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        public string Bcc { get; set; }

        public string CC { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public int TrialCount { get; set; }

        public string EmailTemplateName { get; set; }

        [Required]
        public DateTime SentDateTime { get; set; }
    }
}