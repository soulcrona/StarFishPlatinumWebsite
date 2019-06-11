using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarFishWebsite.Models
{
    public class Environment
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool available { get; set; }
        public FoodType foodType { get; set; }
        public Image image { get; set; }
        public float price { get; set; }
    }
}