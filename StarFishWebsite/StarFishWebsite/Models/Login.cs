using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarFishWebsite.Models
{
    public class Login
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string IPAddress { get; set; }
        public string MachineName { get; set; }
        public DateTime LoginTime { get; set; }
    }
}