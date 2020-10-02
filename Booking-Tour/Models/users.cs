using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class users
    {
        [Key]
        public int id { get; set; }
        [StringLength(30), Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required, EmailAddress]
        public string password { get; set; }
        [MaxLength(255)]
        public string avatar { get; set; }
        [Required]
        public String phone { get; set; }
        public string xaid { get; set; }
        public int permission { get; set; }

        public ICollection<bills> bills { get; set; }
        public ICollection<categorys> categorys { get; set; }
        public ICollection<ratings> ratings { get; set; }

        public DateTime created_At { get; set; }
        public DateTime update_At { get; set; }
    }
}