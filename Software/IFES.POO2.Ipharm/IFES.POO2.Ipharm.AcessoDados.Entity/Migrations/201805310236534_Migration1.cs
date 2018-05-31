namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
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
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUser = c.Guid(nullable: false),
                        Cnpj = c.String(),
                        CompanyName = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCompany = c.Guid(nullable: false),
                        IdPerson = c.Guid(nullable: false),
                        IdEndereco = c.Int(nullable: false),
                        ValueOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderStatus = c.Int(nullable: false),
                        Company_Id = c.Guid(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.ItemOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdOrder = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        ItemValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCompany = c.Guid(nullable: false),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        HasControl = c.Boolean(nullable: false),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdOrder = c.Int(nullable: false),
                        IdPaymentMethod = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        Order_Id = c.Int(),
                        PaymentMethod_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.PaymentMethod_Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPerson = c.Int(nullable: false),
                        PaymentOption = c.Int(nullable: false),
                        Description = c.String(),
                        CardNumber = c.String(),
                        SecurityCode = c.String(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUser = c.Guid(nullable: false),
                        Cpf = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "User_Id", "dbo.User");
            DropForeignKey("dbo.Review", "Id", "dbo.Orders");
            DropForeignKey("dbo.Review", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PaymentMethods", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Orders", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Payments", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Payments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ItemOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.ItemOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Address", "User_Id", "dbo.User");
            DropForeignKey("dbo.Localization", "User_Id", "dbo.User");
            DropIndex("dbo.Review", new[] { "Company_Id" });
            DropIndex("dbo.Review", new[] { "Id" });
            DropIndex("dbo.PaymentMethods", new[] { "Person_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Payments", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Company_Id" });
            DropIndex("dbo.ItemOrders", new[] { "Product_Id" });
            DropIndex("dbo.ItemOrders", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Person_Id" });
            DropIndex("dbo.Orders", new[] { "Company_Id" });
            DropIndex("dbo.Companies", new[] { "User_Id" });
            DropIndex("dbo.Localization", new[] { "User_Id" });
            DropIndex("dbo.Address", new[] { "User_Id" });
            DropTable("dbo.Review");
            DropTable("dbo.People");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Payments");
            DropTable("dbo.Products");
            DropTable("dbo.ItemOrders");
            DropTable("dbo.Orders");
            DropTable("dbo.Companies");
            DropTable("dbo.Localization");
            DropTable("dbo.User");
            DropTable("dbo.Address");
        }
    }
}
