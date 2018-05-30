namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "FoodName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "FoodName", c => c.String());
        }
    }
}
