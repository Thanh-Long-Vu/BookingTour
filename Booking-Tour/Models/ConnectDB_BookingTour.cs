namespace Booking_Tour.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Booking_Tour.Models;

    public partial class ConnectDB_BookingTour : DbContext
    {
        public virtual DbSet<bills> bills { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<categorys> categorys { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<products> products { get; set; }
        public virtual DbSet<region> regions { get; set; }
        public virtual DbSet<provinces> provinces { get; set; }
        public virtual DbSet<ratings> ratings { get; set; }
        public virtual DbSet<uti_pro> uti_pro { get; set; }
        public virtual DbSet<utilities> utilities { get; set; }
        public virtual DbSet<product_types> product_types { get; set; }
        public ConnectDB_BookingTour()
            : base("name=ConnectDB_BookingTour")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
