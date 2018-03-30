using System;

namespace JobHunt.Services.Models.Email
{
    [Serializable]
    public class EmailPendingRequestVerificationToDataOwnerModel : EmailBaseModel
    {
        public string DataOwnerEmail { get; set; }
        public string RequestorEmail { get; set; }
        public string RequestNo { get; set; }
        public string RequestorName { get; set; }
        public string ModuleList { get; set; }
        public Guid RequestId { get; set; }
        public string AccessRequest { get; set; }

      
    }
}