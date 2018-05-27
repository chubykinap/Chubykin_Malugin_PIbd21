namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Mail", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Count", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Storages", "StorageName", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Providers", "Password", c => c.String());
            AlterColumn("dbo.Providers", "Login", c => c.String());
            AlterColumn("dbo.Storages", "StorageName", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Admins", "Login", c => c.String());
            DropColumn("dbo.Products", "Count");
            DropColumn("dbo.Admins", "Mail");
        }
    }
}
