using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models.WebModels
{
    public class ProductModel
    {

     
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string PName { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string PImage { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Display(Name = "Sell Price")]
        public decimal SellPrice { get; set; }

    
        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }
    }
}