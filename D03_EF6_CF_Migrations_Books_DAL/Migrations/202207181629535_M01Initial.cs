namespace D03_EF6_CF_Migrations_Books_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M01Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        PublisherID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        ISBN = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Publisher", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PublisherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "PublisherID", "dbo.Publisher");
            DropIndex("dbo.Book", new[] { "PublisherID" });
            DropTable("dbo.Publisher");
            DropTable("dbo.Book");
        }
    }
}
