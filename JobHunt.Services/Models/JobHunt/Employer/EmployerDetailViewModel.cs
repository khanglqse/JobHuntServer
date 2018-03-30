using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHunt.Services.Models.JobHunt.Employer
{
   public class EmployerDetailViewModel : BaseModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        //public List<Job> Jobs { get; set; }
        //public Address Address { get; set; }
        public string Description { get; set; }
        public int OpenPosition { get; set; }
        public int ViewCount { get; set; }
        public string LogoImage { get; set; }
        public int LongDescription { get; set; }
        public int Followers { get; set; }
        //public Contact Contact { get; set; }
    }
}
