namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_NewsEmilModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsEmails",
                c => new
                    {
                        NewsEmailID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.NewsEmailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsEmails");
        }
    }
}
