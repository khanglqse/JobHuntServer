using System;

namespace JobHunt.Services.Models.Login
{
    [Serializable]
    public class RoleModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}