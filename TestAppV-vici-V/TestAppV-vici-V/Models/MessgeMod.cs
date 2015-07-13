using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppV_vici_V.Models
{
    public class MessgeMod
    {
        public UserMod User { get; set; }
        public string Mess { get; set; }
        public DateTime Time { get; set; }
    }
}