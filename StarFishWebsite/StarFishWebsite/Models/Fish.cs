using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarFishWebsite.Models;

namespace StarFishWebsite.Models
{
    public class Fish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public String Description { get; set; }
        public bool InGame { get; set; }
        public AffiliateLink AffiliateLink { get; set; }
        public String SubDescriptions { get; set; }
        public String PrivateNotes { get; set; } // not a field to be seen on the user side 
        public List<Food> PreferredFood { get; set; }
        public Image ImageCall { get; set; }
        public String MoreDescriptions { get; set; }
        public FishType FishType {get; set;}
        public bool Available { get; set; }
    }
}