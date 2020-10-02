using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class products
    {
        [Key]
        public int id { get; set; }
        public categorys categorys { get; set; }
        public product_types product_types { get; set; }
        [StringLength(30), Required]
        public string name { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int discount { get; set; }
        [MaxLength(255), Required]
        public string avatar { get; set; }
        public int status { get; set; }
        public ICollection<image_products> image_products { get; set; }
        public ICollection<orders> orders { get; set; }

        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}