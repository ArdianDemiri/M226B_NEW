namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Type");
        }
    }
}
