using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
    public class EventView
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public List<ProductView> products { get; set; }
        public string message { get; set; }
    }
}