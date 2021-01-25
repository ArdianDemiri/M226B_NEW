namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "RentTime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RentTime");
        }
    }
}
