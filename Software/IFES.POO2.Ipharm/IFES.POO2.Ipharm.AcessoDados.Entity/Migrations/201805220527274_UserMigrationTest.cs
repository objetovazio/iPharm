namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMigrationTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        USE_USERS = c.Guid(nullable: false, identity: true),
                        USE_LOGIN = c.String(nullable: false, maxLength: 30),
                        USE_NAME = c.String(nullable: false, maxLength: 30),
                        USE_EMAIL = c.String(nullable: false, maxLength: 50),
                        USE_PHONE = c.String(nullable: false, maxLength: 11),
                        USE_ISACTIVE = c.Boolean(nullable: false),
                        LocalizationId = c.Int(nullable: false),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        Cpf1 = c.String(),
                        Birthday = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.USE_USERS);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street_Name = c.String(),
                        Neighborhood = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        CEP = c.String(),
                        Details = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Localizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        UserId = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentOption = c.Int(nullable: false),
                        Description = c.String(),
                        CardNumber = c.String(),
                        SecurityCode = c.String(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentMethods", "Person_Id", "dbo.USERS");
            DropForeignKey("dbo.Localizations", "User_Id", "dbo.USERS");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.USERS");
            DropIndex("dbo.PaymentMethods", new[] { "Person_Id" });
            DropIndex("dbo.Localizations", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Localizations");
            DropTable("dbo.Addresses");
            DropTable("dbo.USERS");
        }
    }
}
