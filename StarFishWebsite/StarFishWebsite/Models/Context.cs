using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StarFishWebsite.Models;

namespace StarFishWebsite.Models
{
    public class Context : DbContext
    {
        public DbSet<Fish> fish { get; set; }
        public DbSet<AffiliateLink> affiliateLinks { get; set; }
        public DbSet<FishType> fishTypes { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<FoodType> foodTypes { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Environment> environments { get; set; }
        public DbSet<Button> buttons { get; set; }
    }
}