using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is required !")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Range(1, 99999999,ErrorMessage ="Price will be greater than 1 ")]
        public Nullable<decimal> Price { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}