namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceForRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Price");
        }
    }
}
