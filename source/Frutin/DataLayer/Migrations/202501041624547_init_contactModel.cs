namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_contactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 150),
                        UserEmail = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false, maxLength: 150),
                        MessageText = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
