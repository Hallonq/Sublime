using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sublime.Models
{
    public class SverigesRadioViewModel
    {
        public List<ProgramModel> programs { get; set; }
        public PodModel[] podfiles { get; set; }
        public List<PodModel[]> podfilesList = new List<PodModel[]>();
    }
}
