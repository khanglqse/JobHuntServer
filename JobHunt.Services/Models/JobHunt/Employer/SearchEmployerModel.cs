﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunt.Services.Models.JobHunt
{ 
    public class SearchEmployerModel
    {
            public string Keyword { get; set; }
            public int PageNumber { get; set; } = 1; //default is 1 and 20
            public int PageSize { get; set; } = 20;
    }
}