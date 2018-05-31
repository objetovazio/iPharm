namespace IFES.POO2.Ipharm.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "Id", "dbo.Orders");
            DropForeignKey("dbo.ItemOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Payments", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Review", new[] { "Id" });
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.Orders", "Review_Id", c => c.Int());
            AlterColumn("dbo.Orders", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "Id");
            CreateIndex("dbo.Orders", "Id");
            CreateIndex("dbo.Orders", "Review_Id");
            AddForeignKey("dbo.Orders", "Review_Id", "dbo.Review", "Id");
            AddForeignKey("dbo.ItemOrders", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Payments", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ItemOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Review_Id", "dbo.Review");
            DropIndex("dbo.Orders", new[] { "Review_Id" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Orders", "Review_Id");
            AddPrimaryKey("dbo.Orders", "Id");
            CreateIndex("dbo.Review", "Id");
            AddForeignKey("dbo.Payments", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.ItemOrders", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Review", "Id", "dbo.Orders", "Id");
        }
    }
}
