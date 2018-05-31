namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street_Name = c.String(nullable: false),
                        Neighborhood = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        CEP = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 11),
                        IsActive = c.Boolean(nullable: false),
                        IsAdministrator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValueOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderStatus = c.Int(nullable: false),
                        Company_Id = c.Guid(nullable: false),
                        Person_Id = c.Guid(),
                        Person_Id1 = c.Guid(nullable: false),
                        Review_Id = c.Int(),
                        Company_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .ForeignKey("dbo.Person", t => t.Person_Id)
                .ForeignKey("dbo.Person", t => t.Person_Id1)
                .ForeignKey("dbo.Review", t => t.Review_Id)
                .ForeignKey("dbo.Company", t => t.Company_Id1)
                .Index(t => t.Id)
                .Index(t => t.Company_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Person_Id1)
                .Index(t => t.Review_Id)
                .Index(t => t.Company_Id1);
            
            CreateTable(
                "dbo.ItemOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.Product", t => t.Id)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        HasControl = c.Boolean(nullable: false),
                        Company_Id = c.Guid(nullable: false),
                        Company_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .ForeignKey("dbo.Company", t => t.Company_Id1)
                .Index(t => t.Company_Id)
                .Index(t => t.Company_Id1);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        PaymentMethod_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Id)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethod_Id)
                .ForeignKey("dbo.PaymentMethod", t => t.Id)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Id)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentOption = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        CardNumber = c.String(),
                        SecurityCode = c.String(),
                        Person_Id = c.Guid(),
                        Person_Id1 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Person_Id)
                .ForeignKey("dbo.Person", t => t.Person_Id1)
                .Index(t => t.Person_Id)
                .Index(t => t.Person_Id1);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Cpf = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        ReviewDetails = c.String(nullable: false, maxLength: 200),
                        Company_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Localization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "User_Id", "dbo.User");
            DropForeignKey("dbo.Localization", "User_Id", "dbo.User");
            DropForeignKey("dbo.Company", "Id", "dbo.User");
            DropForeignKey("dbo.Product", "Company_Id1", "dbo.Company");
            DropForeignKey("dbo.Order", "Company_Id1", "dbo.Company");
            DropForeignKey("dbo.Order", "Review_Id", "dbo.Review");
            DropForeignKey("dbo.Review", "Id", "dbo.Order");
            DropForeignKey("dbo.Review", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Order", "Person_Id1", "dbo.Person");
            DropForeignKey("dbo.Payment", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Payment", "Id", "dbo.PaymentMethod");
            DropForeignKey("dbo.PaymentMethod", "Person_Id1", "dbo.Person");
            DropForeignKey("dbo.Person", "Id", "dbo.User");
            DropForeignKey("dbo.PaymentMethod", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Order", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Payment", "PaymentMethod_Id", "dbo.PaymentMethod");
            DropForeignKey("dbo.Payment", "Id", "dbo.Order");
            DropForeignKey("dbo.ItemOrder", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.ItemOrder", "Id", "dbo.Product");
            DropForeignKey("dbo.ItemOrder", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.ItemOrder", "Id", "dbo.Order");
            DropForeignKey("dbo.Order", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Order", "Id", "dbo.Address");
            DropIndex("dbo.Localization", new[] { "User_Id" });
            DropIndex("dbo.Review", new[] { "Company_Id" });
            DropIndex("dbo.Review", new[] { "Id" });
            DropIndex("dbo.Person", new[] { "Id" });
            DropIndex("dbo.PaymentMethod", new[] { "Person_Id1" });
            DropIndex("dbo.PaymentMethod", new[] { "Person_Id" });
            DropIndex("dbo.Payment", new[] { "Order_Id" });
            DropIndex("dbo.Payment", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Payment", new[] { "Id" });
            DropIndex("dbo.Product", new[] { "Company_Id1" });
            DropIndex("dbo.Product", new[] { "Company_Id" });
            DropIndex("dbo.ItemOrder", new[] { "Order_Id" });
            DropIndex("dbo.ItemOrder", new[] { "Product_Id" });
            DropIndex("dbo.ItemOrder", new[] { "Id" });
            DropIndex("dbo.Order", new[] { "Company_Id1" });
            DropIndex("dbo.Order", new[] { "Review_Id" });
            DropIndex("dbo.Order", new[] { "Person_Id1" });
            DropIndex("dbo.Order", new[] { "Person_Id" });
            DropIndex("dbo.Order", new[] { "Company_Id" });
            DropIndex("dbo.Order", new[] { "Id" });
            DropIndex("dbo.Company", new[] { "Id" });
            DropIndex("dbo.Address", new[] { "User_Id" });
            DropTable("dbo.Localization");
            DropTable("dbo.Review");
            DropTable("dbo.Person");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Payment");
            DropTable("dbo.Product");
            DropTable("dbo.ItemOrder");
            DropTable("dbo.Order");
            DropTable("dbo.Company");
            DropTable("dbo.User");
            DropTable("dbo.Address");
        }
    }
}
