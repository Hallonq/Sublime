using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sublime.Models
{
    public class ProgramModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string socialimage { get; set; }
        public string description { get; set; }
    }
}
