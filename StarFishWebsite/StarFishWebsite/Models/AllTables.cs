using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarFishWebsite.Models
{
    public class AllTables
    {
        public Fish fish { get; set; }
        public AffiliateLink affiliateLink { get; set; }
        public FishType fishType { get; set; }
        public Food food { get; set; }
        public FoodType foodType { get; set; }
        public Image image { get; set; }
        public string filepath { get; set; }
        public bool[] fpyn { get; set; }
        public int[] fpid { get; set; }
    }
}