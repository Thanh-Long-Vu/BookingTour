using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required, MaxLength(30)]
        public string name { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [MaxLength(255)]
        public string avatar { get; set; }
        public bool role { get; set; }
    }
}