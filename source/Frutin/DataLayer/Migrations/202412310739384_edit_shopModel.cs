namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_shopModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "ImageName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "ImageName");
        }
    }
}
