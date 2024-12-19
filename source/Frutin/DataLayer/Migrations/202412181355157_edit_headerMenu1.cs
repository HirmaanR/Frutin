namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_headerMenu1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HeaderMenus", "ParentMenu_HeaderMenuID", c => c.Int());
            CreateIndex("dbo.HeaderMenus", "ParentMenu_HeaderMenuID");
            AddForeignKey("dbo.HeaderMenus", "ParentMenu_HeaderMenuID", "dbo.HeaderMenus", "HeaderMenuID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HeaderMenus", "ParentMenu_HeaderMenuID", "dbo.HeaderMenus");
            DropIndex("dbo.HeaderMenus", new[] { "ParentMenu_HeaderMenuID" });
            DropColumn("dbo.HeaderMenus", "ParentMenu_HeaderMenuID");
        }
    }
}
