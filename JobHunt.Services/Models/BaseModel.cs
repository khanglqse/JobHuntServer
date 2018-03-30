using System;

namespace JobHunt.Services.Models
{
    [Serializable]
    public class BaseModel
    {
 public Guid Id { get; set; }
        public bool IsDelete { get; set; }

        public DateTime InsAt { get; set; }

        public string InsBy { get; set; }

        public DateTime UpdAt { get; set; }

        public string UpdBy { get; set; }
    }
}