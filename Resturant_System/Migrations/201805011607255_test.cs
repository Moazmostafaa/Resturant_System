namespace Resturant_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_id = c.Int(nullable: false),
                        Total_Bill = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_id, cascadeDelete: true)
                .Index(t => t.Order_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TyperID = c.Int(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        Address = c.String(),
                        blocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User_Type", t => t.TyperID, cascadeDelete: true)
                .Index(t => t.TyperID);
            
            CreateTable(
                "dbo.User_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Order_items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        item_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.item_id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.order_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.item_id);
            
            CreateTable(
                "dbo.Pay_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pay_type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total_Price = c.Int(nullable: false),
                        py_type_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Total_Price, cascadeDelete: true)
                .ForeignKey("dbo.Pay_Type", t => t.py_type_id, cascadeDelete: true)
                .Index(t => t.Total_Price)
                .Index(t => t.py_type_id);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "py_type_id", "dbo.Pay_Type");
            DropForeignKey("dbo.Payments", "Total_Price", "dbo.Orders");
            DropForeignKey("dbo.Order_items", "order_id", "dbo.Orders");
            DropForeignKey("dbo.Order_items", "item_id", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Bills", "Order_id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "user_id", "dbo.Users");
            DropForeignKey("dbo.Users", "TyperID", "dbo.User_Type");
            DropIndex("dbo.Payments", new[] { "py_type_id" });
            DropIndex("dbo.Payments", new[] { "Total_Price" });
            DropIndex("dbo.Order_items", new[] { "item_id" });
            DropIndex("dbo.Order_items", new[] { "order_id" });
            DropIndex("dbo.Items", new[] { "CategoryID" });
            DropIndex("dbo.Users", new[] { "TyperID" });
            DropIndex("dbo.Orders", new[] { "user_id" });
            DropIndex("dbo.Bills", new[] { "Order_id" });
            DropTable("dbo.Payments");
            DropTable("dbo.Pay_Type");
            DropTable("dbo.Order_items");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
            DropTable("dbo.User_Type");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Bills");
        }
    }
}
