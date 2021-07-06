using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models.WebModels
{
    public class CartViewModels
    {
        public List<Product> UserCartProducts { get; set; }
        public List<int> CartProductIDS { get; set; }

    }
}