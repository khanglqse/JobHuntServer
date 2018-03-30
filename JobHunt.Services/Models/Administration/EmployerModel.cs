using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHunt.Services.Models.Administration
{
    [Serializable]
    public class EmployerModel : BaseModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string LongDescription { get; set; }
    }
}
