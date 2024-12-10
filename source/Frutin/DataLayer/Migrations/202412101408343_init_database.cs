namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        ShopID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Tittle = c.String(nullable: false, maxLength: 200),
                        ShortDes = c.String(nullable: false, maxLength: 300),
                        Text = c.String(nullable: false, maxLength: 500),
                        CoverImage = c.String(maxLength: 150),
                        DesImage = c.String(maxLength: 150),
                        CreateDate = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopID, cascadeDelete: true)
                .Index(t => t.ShopID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.BlogTags",
                c => new
                    {
                        BlogTagID = c.Int(nullable: false, identity: true),
                        BlogID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogTagID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.BlogID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductTagID = c.Int(nullable: false, identity: true),
                        TagID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTagID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        ImageName = c.String(nullable: false, maxLength: 150),
                        Price = c.Double(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Count = c.Int(nullable: false),
                        OffPercent = c.Double(nullable: false),
                        IsOffer = c.Boolean(nullable: false),
                        Shops_ShopID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.Shops_ShopID)
                .Index(t => t.CategoryID)
                .Index(t => t.Shops_ShopID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        ParentCategoryID = c.Int(nullable: false),
                        Tittle = c.String(nullable: false, maxLength: 150),
                        EntityType = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        TowardID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                        IsReplay = c.Boolean(nullable: false),
                        Tittle = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false, maxLength: 300),
                        Product_ProductID = c.Int(),
                        Blog_BlogID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogID)
                .Index(t => t.UserID)
                .Index(t => t.Product_ProductID)
                .Index(t => t.Blog_BlogID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 250),
                        ImageName = c.String(nullable: false, maxLength: 150),
                        IsSeller = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        ShopID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        ShortDes = c.String(nullable: false, maxLength: 300),
                        Description = c.String(nullable: false, maxLength: 500),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Site = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 350),
                    })
                .PrimaryKey(t => t.ShopID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ShopID)
                .Index(t => t.ShopID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkID = c.Int(nullable: false, identity: true),
                        ShopID = c.Int(nullable: false),
                        Tittle = c.String(nullable: false, maxLength: 150),
                        URL = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.LinkID)
                .ForeignKey("dbo.Shops", t => t.ShopID, cascadeDelete: true)
                .Index(t => t.ShopID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 350),
                        PostCode = c.Int(nullable: false),
                        SumPrice = c.Double(nullable: false),
                        Status = c.String(nullable: false, maxLength: 150),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderProductID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderProductID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Comments", "Blog_BlogID", "dbo.Blogs");
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Comments", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Shops", "ShopID", "dbo.Users");
            DropForeignKey("dbo.Shops", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Products", "Shops_ShopID", "dbo.Shops");
            DropForeignKey("dbo.Links", "ShopID", "dbo.Shops");
            DropForeignKey("dbo.Blogs", "ShopID", "dbo.Shops");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.BlogTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.BlogTags", "BlogID", "dbo.Blogs");
            DropIndex("dbo.OrderProducts", new[] { "OrderID" });
            DropIndex("dbo.OrderProducts", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Links", new[] { "ShopID" });
            DropIndex("dbo.Shops", new[] { "RoleID" });
            DropIndex("dbo.Shops", new[] { "ShopID" });
            DropIndex("dbo.Comments", new[] { "Blog_BlogID" });
            DropIndex("dbo.Comments", new[] { "Product_ProductID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "Shops_ShopID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.BlogTags", new[] { "TagID" });
            DropIndex("dbo.BlogTags", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropIndex("dbo.Blogs", new[] { "ShopID" });
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Roles");
            DropTable("dbo.Links");
            DropTable("dbo.Shops");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.BlogTags");
            DropTable("dbo.Blogs");
        }
    }
}
