using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobHunt.Services.Models.Login
{
    [Serializable]
    public class UserModel : BaseModel
    {
        public UserModel()
        {
            UpdatedAt = DateTime.Now;
            IsActive = true;
            CostCenterIds = new List<Guid>();
        }

        public string Domain { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Staff Number")]
        public string StaffNumber { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public string ThumbnailPhoto { get; set; }
        public string PositionId { get; set; }
        public Guid? ICTUserProfileId { get; set; }
        public Guid? ICTUserInformationId { get; set; }

        //use for user picker
        public int Index { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string RequesterName { get; set; }

        public string StaffId { get; set; }
        public string Passport { get; set; }
        public string OPU { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string PositionOid { get; set; }
        public string PositionName { get; set; }
        public string ExtensionNo { get; set; }
        public string MobileNo { get; set; }
        public string CostCenter { get; set; }

        //End of user picker
        public List<Guid> CostCenterIds { get; set; }

        [Display(Name = "Role")]
        public ICollection<RoleModel> Roles { get; set; }

        public string Source { get; set; }
        //public Guid UserInfomationId { get; set; }
    }
}