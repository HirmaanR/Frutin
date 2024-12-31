namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_AboutComment : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.AboutComments");
        }
    }
}
