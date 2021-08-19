namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTypePriceOfRecipeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Price", c => c.String());
        }
    }
}
