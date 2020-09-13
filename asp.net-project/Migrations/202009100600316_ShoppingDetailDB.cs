namespace asp.net_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingDetailDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingDetails",
                c => new
                    {
                        ShoppingDetailId = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        Addres = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        OrderId = c.Int(),
                        AmountPaid = c.Decimal(precision: 18, scale: 2),
                        PaymentType = c.String(),
                        Client_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingDetailId)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingDetails", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingDetails", new[] { "Client_Id" });
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            DropTable("dbo.ShoppingDetails");
        }
    }
}
