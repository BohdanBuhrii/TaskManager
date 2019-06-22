namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "IsDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tasks", "Publisher_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Group_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "Title", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 254, unicode: false));
            AlterColumn("dbo.Users", "HashPassword", c => c.String(nullable: false, maxLength: 88, unicode: false));
            AlterColumn("dbo.Tasks", "Content", c => c.String(nullable: false, maxLength: 500, unicode: false));
            CreateIndex("dbo.Tasks", "Publisher_Id");
            CreateIndex("dbo.Tasks", "Group_Id");
            AddForeignKey("dbo.Tasks", "Publisher_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "Group_Id", "dbo.Groups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Tasks", "Publisher_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "Group_Id" });
            DropIndex("dbo.Tasks", new[] { "Publisher_Id" });
            AlterColumn("dbo.Tasks", "Content", c => c.String());
            AlterColumn("dbo.Users", "HashPassword", c => c.String(nullable: false, maxLength: 88));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Title", c => c.String());
            DropColumn("dbo.Tasks", "Group_Id");
            DropColumn("dbo.Tasks", "Publisher_Id");
            DropColumn("dbo.Tasks", "IsDone");
        }
    }
}
