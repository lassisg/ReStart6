namespace RSGym_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M02_Up_CompletedAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "CompletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Request", "CompletedAt");
        }
    }
}
