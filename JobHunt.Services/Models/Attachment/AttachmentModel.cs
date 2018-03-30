using System;

namespace JobHunt.Services.Models.Attachment
{
    [Serializable]
    public class AttachmentModel : BaseModel
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string IncidentTitle { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        public string ModifyUser { get; set; }
    }
}