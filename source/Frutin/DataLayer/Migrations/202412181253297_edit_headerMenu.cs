namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_headerMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HeaderMenus", "Link", c => c.String(nullable: false, maxLength: 350));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HeaderMenus", "Link");
        }
    }
}
