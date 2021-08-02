using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MyCartModel
    {
        public int CartId { get; set; }
        public int PId { get; set; }
        public string UserKey { get; set; }
        public int PQuantity { get; set; }
        public string PName { get; set; }
    }
}