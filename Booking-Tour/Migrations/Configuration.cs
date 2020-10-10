﻿namespace Booking_Tour.Migrations
{
    using Booking_Tour.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Booking_Tour.Models.ConnectDB_BookingTour>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Booking_Tour.Models.ConnectDB_BookingTour context)
        {
            //  This method will be called after migrating to the latest version.
            context.Regions.AddOrUpdate(x => x.name,
                new Regions { name = "Miền Bắc" }, //Id miền bắc bằng: 1
                new Regions { name = "Miền Trung" }, //Id Miền trung: 2
                new Regions { name = "Miền Nam" }  //id miền nam: 3
            );

            context.Provinces.AddOrUpdate(x => x.name,
                new Provinces
                {
                    name = "Hà Nội",
                    region_id = 1,
                },
                new Provinces
                {
                    name = "Lào Cai",
                    region_id = 1,
                },
                new Provinces
                {
                    name = "Mộc Châu",
                    region_id = 1,
                }
            );

            context.Tours.AddOrUpdate(x => x.name,
                new Tours
                {
                    name = "Tour thứ 1",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 100,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 3,
                },
                new Tours
                {
                    name = "Tour thứ 2",
                    day = "3 ngày 2 đêm",
                    description = "Mô tả ở đây",
                    price = 200,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 2,
                },
                new Tours
                {
                    name = "Tour thứ 3",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 100,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 4,
                },
                new Tours
                {
                    name = "Tour thứ 4",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 100,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 2,
                },
                new Tours
                {
                    name = "Tour thứ 5",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 100,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 2,
                },
                new Tours
                {
                    name = "Tour thứ 6",
                    day = "1 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 1000,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 4,
                },
                new Tours
                {
                    name = "Tour thứ 7",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 1500,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 3,
                },
                new Tours
                {
                    name = "Tour thứ 8",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 100000,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 2,
                },
                new Tours
                {
                    name = "Tour thứ 9",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 1500,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 3,
                },
                new Tours
                {
                    name = "Tour thứ 10",
                    day = "4 ngày 3 đêm",
                    description = "Mô tả ở đây",
                    price = 100000,
                    status = true,
                    avatar = "Đây là ảnh",
                    created_at = DateTime.Today,
                    update_at = DateTime.Today,
                    provinces_id = 2,
                }
            );
        }
    }
}
