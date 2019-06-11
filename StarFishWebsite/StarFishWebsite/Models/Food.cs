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
        public int AccessLevel { get; set; }
        public float price { get; set; }
        public Image icon { get; set; }
    }
}