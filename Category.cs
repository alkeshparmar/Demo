using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class Category
    {
        public int cid { get; set; }
        public string cname { get; set; }
        public string cdescription { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

    }
}