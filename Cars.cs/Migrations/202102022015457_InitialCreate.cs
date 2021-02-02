namespace Cars.cs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarBrand = c.String(),
                        CarModel = c.String(),
                        GosNumber = c.String(),
                        AutoYear = c.Int(nullable: false),
                        Color = c.String(),
                        CarMileage = c.Double(nullable: false),
                        FuelVolume = c.Double(nullable: false),
                        AvFuel = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Refuelings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Volume = c.Double(nullable: false),
                        CarMileage = c.Double(nullable: false),
                        AutoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autoes", t => t.AutoId)
                .Index(t => t.AutoId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        AutoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autoes", t => t.AutoId)
                .Index(t => t.AutoId);
            
            CreateTable(
                "dbo.SpareParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        AutoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autoes", t => t.AutoId)
                .Index(t => t.AutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpareParts", "AutoId", "dbo.Autoes");
            DropForeignKey("dbo.Services", "AutoId", "dbo.Autoes");
            DropForeignKey("dbo.Refuelings", "AutoId", "dbo.Autoes");
            DropIndex("dbo.SpareParts", new[] { "AutoId" });
            DropIndex("dbo.Services", new[] { "AutoId" });
            DropIndex("dbo.Refuelings", new[] { "AutoId" });
            DropTable("dbo.SpareParts");
            DropTable("dbo.Services");
            DropTable("dbo.Refuelings");
            DropTable("dbo.Autoes");
        }
    }
}
