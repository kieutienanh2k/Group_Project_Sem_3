namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.OrderDetails", new[] { "RecipeId" });
            DropColumn("dbo.OrderDetails", "RecipeId");
            DropTable("dbo.Recipes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderDetails", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "RecipeId");
            AddForeignKey("dbo.OrderDetails", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
