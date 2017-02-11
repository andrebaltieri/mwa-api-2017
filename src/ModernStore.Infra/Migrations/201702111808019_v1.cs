namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(nullable: false, maxLength: 60),
                        Name_LastName = c.String(nullable: false, maxLength: 60),
                        BirthDate = c.DateTime(),
                        Email_Address = c.String(nullable: false, maxLength: 160),
                        Document_Number = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        User_Username = c.String(nullable: false, maxLength: 20),
                        User_Password = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        User_Active = c.Boolean(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Number = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        Status = c.Int(nullable: false),
                        DeliveryFee = c.Decimal(nullable: false, storeType: "money"),
                        Discount = c.Decimal(nullable: false, storeType: "money"),
                        Customer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Product_Id = c.Guid(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 80),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(nullable: false, maxLength: 1024),
                        QuantityOnHand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.OrderItem", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "Product_Id" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
