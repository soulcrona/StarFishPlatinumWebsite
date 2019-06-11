using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarFishWebsite.Models
{
    public class FoodType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public int AccessLevel { get; set; }
    }
}