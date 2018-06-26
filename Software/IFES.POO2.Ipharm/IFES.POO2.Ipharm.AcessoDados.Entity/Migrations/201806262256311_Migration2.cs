namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Localization", new[] { "Id" });
            DropPrimaryKey("dbo.Localization");
            AlterColumn("dbo.Localization", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Localization", "Id");
            CreateIndex("dbo.Localization", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Localization", new[] { "Id" });
            DropPrimaryKey("dbo.Localization");
            AlterColumn("dbo.Localization", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Localization", "Id");
            CreateIndex("dbo.Localization", "Id");
        }
    }
}
