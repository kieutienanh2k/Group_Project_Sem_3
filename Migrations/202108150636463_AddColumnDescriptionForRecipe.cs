namespace ProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDescriptionForRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Description");
        }
    }
}
