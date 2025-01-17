namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_FaqModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        FaqID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 200),
                        Answer = c.String(nullable: false, maxLength: 500),
                        IsAviable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FaqID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Faqs");
        }
    }
}
