namespace BLService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Price = c.String(),
                        Category = c.String(),
                        Date = c.DateTime(nullable: false),
                        Shop_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Shops", t => t.Shop_Id, cascadeDelete: true)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.Products", new[] { "Shop_Id" });
            DropTable("dbo.Shops");
            DropTable("dbo.Products");
        }
    }
}
