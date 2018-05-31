namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
