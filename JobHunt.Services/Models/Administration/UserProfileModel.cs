﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHunt.Data.Entities.Login;

namespace JobHunt.Services.Models.Administration
{
    [Serializable]
    public class UserProfileModel : BaseModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; internal set; }
    }
}
