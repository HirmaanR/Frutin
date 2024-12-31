namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImageName");
        }
    }
}
