namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Vehicle_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_ID)
                .Index(t => t.User_Id)
                .Index(t => t.Vehicle_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Vehicle_ID", "dbo.Vehicles");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Vehicle_ID" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropTable("dbo.Orders");
        }
    }
}
