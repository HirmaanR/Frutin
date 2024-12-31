namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_commentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsAboutComment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "IsAboutComment");
        }
    }
}
