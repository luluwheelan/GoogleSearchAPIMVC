using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SearchEngine.Models;

namespace SearchEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowResults()
        {
            string searchQuery = Request["search"];
            string cx = "SearchEngineID";
            string apiKey = "APIKey";
            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<Result>();
            foreach(var item in jsonData.items)
            {
                results.Add(new Result
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet,
                });
            }
            return View(results.ToList());
        }


    }
}