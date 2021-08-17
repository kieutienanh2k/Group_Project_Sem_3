namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorRoleNotExistAdmin : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AlterColumn("dbo.Feedbacks", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AlterColumn("dbo.Feedbacks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UserId");
        }
    }
}
