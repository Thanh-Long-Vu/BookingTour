namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        email = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        note = c.String(),
                        status = c.Int(nullable: false),
                        payments = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        users_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.users_id)
                .Index(t => t.users_id);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        date_start = c.DateTime(nullable: false),
                        date_end = c.DateTime(nullable: false),
                        price = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        bill_id = c.Int(),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bills", t => t.bill_id)
                .ForeignKey("dbo.products", t => t.product_id)
                .Index(t => t.bill_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        price = c.Int(nullable: false),
                        discount = c.Int(nullable: false),
                        avatar = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        categorys_id = c.Int(),
                        product_types_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categorys", t => t.categorys_id)
                .ForeignKey("dbo.product_types", t => t.product_types_id)
                .Index(t => t.categorys_id)
                .Index(t => t.product_types_id);
            
            CreateTable(
                "dbo.categorys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        avatar = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 255),
                        point = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        user_id = c.Int(),
                        region_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.user_id)
                .ForeignKey("dbo.regions", t => t.region_id)
                .Index(t => t.user_id)
                .Index(t => t.region_id);
            
            CreateTable(
                "dbo.ratings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        point = c.Int(nullable: false),
                        comments = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        bill_id = c.Int(),
                        categorys_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bills", t => t.bill_id)
                .ForeignKey("dbo.categorys", t => t.categorys_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.bill_id)
                .Index(t => t.categorys_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        avatar = c.String(maxLength: 255),
                        phone = c.String(nullable: false),
                        xaid = c.String(),
                        permission = c.Int(nullable: false),
                        created_At = c.DateTime(nullable: false),
                        update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.regions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        ma_mien = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.provinces",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        ma_tp = c.String(),
                        region_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.regions", t => t.region_id)
                .Index(t => t.region_id);
            
            CreateTable(
                "dbo.image_products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        url = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.products", t => t.product_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.product_types",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        status = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.uti_pro",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        products_id = c.Int(),
                        utilities_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.products", t => t.products_id)
                .ForeignKey("dbo.utilities", t => t.utilities_id)
                .Index(t => t.products_id)
                .Index(t => t.utilities_id);
            
            CreateTable(
                "dbo.utilities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        status = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.uti_pro", "utilities_id", "dbo.utilities");
            DropForeignKey("dbo.uti_pro", "products_id", "dbo.products");
            DropForeignKey("dbo.products", "product_types_id", "dbo.product_types");
            DropForeignKey("dbo.orders", "product_id", "dbo.products");
            DropForeignKey("dbo.image_products", "product_id", "dbo.products");
            DropForeignKey("dbo.provinces", "region_id", "dbo.regions");
            DropForeignKey("dbo.categorys", "region_id", "dbo.regions");
            DropForeignKey("dbo.ratings", "user_id", "dbo.users");
            DropForeignKey("dbo.categorys", "user_id", "dbo.users");
            DropForeignKey("dbo.bills", "users_id", "dbo.users");
            DropForeignKey("dbo.ratings", "categorys_id", "dbo.categorys");
            DropForeignKey("dbo.ratings", "bill_id", "dbo.bills");
            DropForeignKey("dbo.products", "categorys_id", "dbo.categorys");
            DropForeignKey("dbo.orders", "bill_id", "dbo.bills");
            DropIndex("dbo.uti_pro", new[] { "utilities_id" });
            DropIndex("dbo.uti_pro", new[] { "products_id" });
            DropIndex("dbo.image_products", new[] { "product_id" });
            DropIndex("dbo.provinces", new[] { "region_id" });
            DropIndex("dbo.ratings", new[] { "user_id" });
            DropIndex("dbo.ratings", new[] { "categorys_id" });
            DropIndex("dbo.ratings", new[] { "bill_id" });
            DropIndex("dbo.categorys", new[] { "region_id" });
            DropIndex("dbo.categorys", new[] { "user_id" });
            DropIndex("dbo.products", new[] { "product_types_id" });
            DropIndex("dbo.products", new[] { "categorys_id" });
            DropIndex("dbo.orders", new[] { "product_id" });
            DropIndex("dbo.orders", new[] { "bill_id" });
            DropIndex("dbo.bills", new[] { "users_id" });
            DropTable("dbo.utilities");
            DropTable("dbo.uti_pro");
            DropTable("dbo.product_types");
            DropTable("dbo.image_products");
            DropTable("dbo.provinces");
            DropTable("dbo.regions");
            DropTable("dbo.users");
            DropTable("dbo.ratings");
            DropTable("dbo.categorys");
            DropTable("dbo.products");
            DropTable("dbo.orders");
            DropTable("dbo.bills");
        }
    }
}
