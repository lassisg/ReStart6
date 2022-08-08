namespace RSGym_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M01_Initial_state : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TrainerID = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Message = c.String(maxLength: 254),
                        MessageAt = c.DateTime(),
                        CompletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Trainer", t => t.TrainerID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TrainerID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.TrainerID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "UserID", "dbo.User");
            DropForeignKey("dbo.Request", "TrainerID", "dbo.Trainer");
            DropIndex("dbo.Request", new[] { "UserID" });
            DropIndex("dbo.Request", new[] { "TrainerID" });
            DropTable("dbo.User");
            DropTable("dbo.Trainer");
            DropTable("dbo.Request");
        }
    }
}
