namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "PaymentId" });
            RenameColumn(table: "dbo.Orders", name: "PaymentId", newName: "Payment_Id");
            AddColumn("dbo.Orders", "Payment", c => c.String());
            AlterColumn("dbo.Orders", "Payment_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Payment_Id");
            AddForeignKey("dbo.Orders", "Payment_Id", "dbo.Payments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "Payment_Id" });
            AlterColumn("dbo.Orders", "Payment_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Payment");
            RenameColumn(table: "dbo.Orders", name: "Payment_Id", newName: "PaymentId");
            CreateIndex("dbo.Orders", "PaymentId");
            AddForeignKey("dbo.Orders", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
        }
    }
}
