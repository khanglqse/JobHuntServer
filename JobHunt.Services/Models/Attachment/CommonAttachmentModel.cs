using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHunt.Services.Models.Attachment
{
    public class CommonAttachmentModel:BaseModel
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
    }
}
