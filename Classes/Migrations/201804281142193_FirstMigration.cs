namespace Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        FoodName = c.String(nullable: false),
                        something1 = c.Int(nullable: false),
                        something2 = c.Int(nullable: false),
                        something3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.ProductRequirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.ProductStorages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.AdminId)
                .Index(t => t.ProviderId)
                .Index(t => t.StorageId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Foods", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Transfers", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.Transfers", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Storages", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Products", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Transfers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transfers", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.ProductStorages", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.ProductStorages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductRequirements", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductRequirements", "FoodId", "dbo.Foods");
            DropIndex("dbo.Transfers", new[] { "ProductId" });
            DropIndex("dbo.Transfers", new[] { "StorageId" });
            DropIndex("dbo.Transfers", new[] { "ProviderId" });
            DropIndex("dbo.Transfers", new[] { "AdminId" });
            DropIndex("dbo.Storages", new[] { "ProviderId" });
            DropIndex("dbo.ProductStorages", new[] { "ProductId" });
            DropIndex("dbo.ProductStorages", new[] { "StorageId" });
            DropIndex("dbo.Products", new[] { "ProviderId" });
            DropIndex("dbo.Products", new[] { "AdminId" });
            DropIndex("dbo.ProductRequirements", new[] { "ProductId" });
            DropIndex("dbo.ProductRequirements", new[] { "FoodId" });
            DropIndex("dbo.Foods", new[] { "AdminId" });
            DropTable("dbo.Providers");
            DropTable("dbo.Transfers");
            DropTable("dbo.Storages");
            DropTable("dbo.ProductStorages");
            DropTable("dbo.Products");
            DropTable("dbo.ProductRequirements");
            DropTable("dbo.Foods");
            DropTable("dbo.Admins");
        }
    }
}
