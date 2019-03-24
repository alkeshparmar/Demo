using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class Product
    {
        public int pid { get; set; }
        public int cid { get; set; }
        public string pname { get; set; }
        public decimal pprice { get; set; }
        public string pdescription { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string images { get; set; }
        public int Quantity { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

        public string ImageURL { get; set; }
    }
}