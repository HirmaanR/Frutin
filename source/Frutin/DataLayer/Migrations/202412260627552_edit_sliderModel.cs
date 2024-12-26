
namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_sliderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Link", c => c.String(maxLength: 300));
            AddColumn("dbo.Sliders", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "IsActive");
            DropColumn("dbo.Sliders", "Link");
        }
    }
}
