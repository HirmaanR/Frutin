namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_headrModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeaderMenus",
                c => new
                    {
                        HeaderMenuID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        IsMenuChild = c.Boolean(nullable: false),
                        ParentMenuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeaderMenuID);
            
            CreateTable(
                "dbo.HeaderNotifications",
                c => new
                    {
                        HeaderNotofocationID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 350),
                        IsAviable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HeaderNotofocationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeaderNotifications");
            DropTable("dbo.HeaderMenus");
        }
    }
}
