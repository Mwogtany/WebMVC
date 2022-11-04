using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class MainMenuViewModel
    {
        public string HrefPath { get; set; }
        public string LinkTitle { get; set; }
        public string ssmenkey { get; set; }
        public string MenuType { get; set; }
    }
    public class SubMenuViewModel
    {
        public string HrefPath { get; set; }
        public string LinkTitle { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}