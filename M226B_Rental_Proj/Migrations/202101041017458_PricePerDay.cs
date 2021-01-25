namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PricePerDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PriceVehicle", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PriceVehicle");
        }
    }
}
