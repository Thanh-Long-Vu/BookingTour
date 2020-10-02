using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class region
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<categorys> categorys { get; set; }
        public ICollection<provinces> provinces { get; set; }
        public string ma_mien { get; set; }
    }
}