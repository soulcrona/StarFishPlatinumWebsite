using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarFishWebsite.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] ImageFile { get; set; }
    }
}