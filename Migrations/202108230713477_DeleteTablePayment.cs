namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTablePayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "Payment_Id" });
            DropColumn("dbo.Orders", "Payment_Id");
            DropTable("dbo.Payments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Form = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Payment_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Payment_Id");
            AddForeignKey("dbo.Orders", "Payment_Id", "dbo.Payments", "Id");
        }
    }
}
