namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_slider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 100),
                        Caption = c.String(nullable: false, maxLength: 200),
                        IsAviable = c.Boolean(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.SliderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
