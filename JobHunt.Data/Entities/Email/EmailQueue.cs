using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Data.Entities.Email
{
    [Serializable]
    [Table("EmailQueue")]
    public class EmailQueue : EntityBase
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Bcc { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int TrialCount { get; set; }
        public string EmailTemplateName { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}