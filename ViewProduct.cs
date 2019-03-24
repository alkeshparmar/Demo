using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class ViewProduct
    {
        public Category CategoryVM { get; set; }
        public Product ProductVM { get; set; }
    }
}