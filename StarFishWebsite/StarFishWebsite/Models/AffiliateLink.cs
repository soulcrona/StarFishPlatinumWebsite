using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarFishWebsite.Models
{
    public class AffiliateLink
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
    }
}