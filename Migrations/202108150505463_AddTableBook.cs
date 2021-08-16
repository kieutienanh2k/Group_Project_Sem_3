namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderDetails", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "BookId");
            AddForeignKey("dbo.OrderDetails", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "BookId", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "BookId" });
            DropColumn("dbo.OrderDetails", "BookId");
            DropTable("dbo.Books");
        }
    }
}
