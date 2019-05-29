using System;
using System.Collections.Generic;
using System.Linq;
using StarFishWebsite.Models;
using System.Web;

namespace StarFishWebsite.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public FoodType TypeofFood { get; set; }
        public bool InGame { get; set; }
        public List<Fish> preferringfish {get; set;}
        public bool Available { get; set; }
    }
}