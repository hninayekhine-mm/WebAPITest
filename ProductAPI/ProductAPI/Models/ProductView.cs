using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
    public class ProductView
    {
        public long id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double sale_amount { get; set; }
    }
}