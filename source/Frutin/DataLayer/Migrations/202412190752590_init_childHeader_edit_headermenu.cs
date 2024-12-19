namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_childHeader_edit_headermenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HeaderMenus", "ParentMenu_HeaderMenuID", "dbo.HeaderMenus");
            DropIndex("dbo.HeaderMenus", new[] { "ParentMenu_HeaderMenuID" });
            CreateTable(
                "dbo.ChildHeaderMenus",
                c => new
                    {
                        ChildMenuID = c.Int(nullable: false, identity: true),
                        HeaderMenuID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 350),
                    })
                .PrimaryKey(t => t.ChildMenuID)
                .ForeignKey("dbo.HeaderMenus", t => t.HeaderMenuID, cascadeDelete: true)
                .Index(t => t.HeaderMenuID);
            
            AddColumn("dbo.HeaderMenus", "IsMenuHasChild", c => c.Boolean(nullable: false));
            DropColumn("dbo.HeaderMenus", "IsMenuChild");
            DropColumn("dbo.HeaderMenus", "ParentMenuID");
            DropColumn("dbo.HeaderMenus", "ParentMenu_HeaderMenuID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HeaderMenus", "ParentMenu_HeaderMenuID", c => c.Int());
            AddColumn("dbo.HeaderMenus", "ParentMenuID", c => c.Int(nullable: false));
            AddColumn("dbo.HeaderMenus", "IsMenuChild", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ChildHeaderMenus", "HeaderMenuID", "dbo.HeaderMenus");
            DropIndex("dbo.ChildHeaderMenus", new[] { "HeaderMenuID" });
            DropColumn("dbo.HeaderMenus", "IsMenuHasChild");
            DropTable("dbo.ChildHeaderMenus");
            CreateIndex("dbo.HeaderMenus", "ParentMenu_HeaderMenuID");
            AddForeignKey("dbo.HeaderMenus", "ParentMenu_HeaderMenuID", "dbo.HeaderMenus", "HeaderMenuID");
        }
    }
}
