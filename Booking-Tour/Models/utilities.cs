using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class utilities
    {
        [Key]
        public int id { get; set; }
        [Required, MaxLength(50)]
        public string name { get; set; }
        public int status { get; set; }
        public ICollection<uti_pro> uti_pro { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }
    }
}