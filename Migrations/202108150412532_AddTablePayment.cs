namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePayment : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Orders", "PaymentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "PaymentId");
            AddForeignKey("dbo.Orders", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "PaymentId" });
            DropColumn("dbo.Orders", "PaymentId");
            DropTable("dbo.Payments");
        }
    }
}
