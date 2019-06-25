namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FromEFCoreToEF6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserGroup");
            AddPrimaryKey("dbo.UserGroup", new[] { "GroupId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserGroup");
            AddPrimaryKey("dbo.UserGroup", new[] { "UserId", "GroupId" });
        }
    }
}
