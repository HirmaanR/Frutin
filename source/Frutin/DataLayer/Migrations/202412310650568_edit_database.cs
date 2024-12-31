namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_database : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AboutComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AboutComments",
                c => new
                    {
                        AboutCommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        UserName = c.String(nullable: false, maxLength: 100),
                        UserRole = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutCommentID);
            
        }
    }
}
