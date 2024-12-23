namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_footerContent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FooterContents",
                c => new
                    {
                        FooterContentID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 400),
                        Address = c.String(nullable: false, maxLength: 300),
                        PhoneNumber = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        IsAviable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FooterContentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FooterContents");
        }
    }
}
