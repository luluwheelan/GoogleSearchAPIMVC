using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchEngine.Models
{
    public class Result
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Scource { get; set; }
        public string Query { get; set; }
        public string Index { get; set; }
    }
}