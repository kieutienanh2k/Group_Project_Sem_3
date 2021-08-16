namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableRecipe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderDetails", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "RecipeId");
            AddForeignKey("dbo.OrderDetails", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.OrderDetails", new[] { "RecipeId" });
            DropColumn("dbo.OrderDetails", "RecipeId");
            DropTable("dbo.Recipes");
        }
    }
}
