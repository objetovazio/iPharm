namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Guid(nullable: false),
                        Street_Name = c.String(),
                        Neighborhood = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        CEP = c.String(),
                        Details = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        USE_IdUsers = c.Guid(nullable: false, identity: true),
                        USE_Login = c.String(nullable: false, maxLength: 30),
                        USE_Name = c.String(nullable: false, maxLength: 30),
                        USE_Email = c.String(nullable: false, maxLength: 50),
                        USE_Phone = c.String(nullable: false, maxLength: 11),
                        USE_IsActive = c.Boolean(nullable: false),
                        USE_IsAdministrator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.USE_IdUsers);
            
            CreateTable(
                "dbo.LOCALIZATION",
                c => new
                    {
                        LOC_IdLocalization = c.Int(nullable: false, identity: true),
                        USE_IdUsers = c.Guid(nullable: false),
                        LOC_Latitude = c.Single(nullable: false),
                        LOC_Longitude = c.Single(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LOC_IdLocalization)
                .ForeignKey("dbo.USERS", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOCALIZATION", "User_Id", "dbo.USERS");
            DropForeignKey("dbo.Addresses", "User_Id", "dbo.USERS");
            DropIndex("dbo.LOCALIZATION", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "User_Id" });
            DropTable("dbo.LOCALIZATION");
            DropTable("dbo.USERS");
            DropTable("dbo.Addresses");
        }
    }
}
