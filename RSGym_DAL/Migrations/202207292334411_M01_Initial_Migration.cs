namespace RSGym_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M01_Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TrainnerID = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        RequestHour = c.Time(nullable: false, precision: 7),
                        CreatedAt = c.DateTime(nullable: false),
                        Message = c.String(maxLength: 254),
                        MessageAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Trainner", t => t.TrainnerID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TrainnerID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Trainner",
                c => new
                    {
                        TrainnerID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.TrainnerID);
            
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
            DropForeignKey("dbo.Request", "TrainnerID", "dbo.Trainner");
            DropIndex("dbo.Request", new[] { "UserID" });
            DropIndex("dbo.Request", new[] { "TrainnerID" });
            DropTable("dbo.User");
            DropTable("dbo.Trainner");
            DropTable("dbo.Request");
        }
    }
}
