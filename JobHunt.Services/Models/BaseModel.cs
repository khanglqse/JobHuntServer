using System;

namespace JobHunt.Services.Models
{
    [Serializable]
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid InsertedBy { get; set; }
        public DateTime InsertedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}