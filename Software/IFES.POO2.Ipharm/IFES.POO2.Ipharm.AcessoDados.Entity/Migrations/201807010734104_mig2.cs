namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Company", "Cnpj", c => c.String(nullable: false, maxLength: 19));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "Cnpj", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
