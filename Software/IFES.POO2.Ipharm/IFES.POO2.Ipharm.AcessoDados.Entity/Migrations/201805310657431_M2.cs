namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "U_User");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.U_User", newName: "User");
        }
    }
}
