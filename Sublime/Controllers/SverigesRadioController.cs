using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sublime.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sublime.Controllers
{
    public class SverigesRadioController : Controller
    {
        List<int> idList = new List<int>();
        SverigesRadioViewModel srvm = new SverigesRadioViewModel();

        public IActionResult Get()
        {
            // PROGRAMS START
            string programurl = "http://api.sr.se/api/v2/programs/index?programcategoryid=133&format=json&filter=program.haspod&filterValue=true&isarchived=false&pagination=false";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(programurl);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader sw = new StreamReader(httpResponse.GetResponseStream()))
            {
                SverigesRadioViewModel programs = JsonConvert.DeserializeObject<SverigesRadioViewModel>(sw.ReadToEnd());
                srvm.programs = programs.programs;
                foreach (var program in srvm.programs)
                {
                    //if (program.id)
                    //{

                    //}
                }

                foreach (var id in programs.programs)
                {
                    idList.Add(id.id);
                }
            }
            // PROGRAMS END

            // PODS START
            for (int i = 0; i < idList.Count; i++)
            {
                string podurl = "http://api.sr.se/api/v2/podfiles?programid=" + idList[i] + "&format=json&pagination=false";

                httpWebRequest = (HttpWebRequest)WebRequest.Create(podurl);
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json";

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader sw = new StreamReader(httpResponse.GetResponseStream()))
                {
                    SverigesRadioViewModel podfiles = JsonConvert.DeserializeObject<SverigesRadioViewModel>(sw.ReadToEnd());

                    if (i != 9 && i != 10 && i != 12 && i != 13 && i != 14 && i != 2)
                    {
                        foreach (var pod in podfiles.podfiles)
                        {
                            pod.programID = idList[i];
                        }

                        srvm.podfilesList.Add(podfiles.podfiles);
                    }
                }
            }

            // PODS END

            return View(srvm);
        }
    }
}
