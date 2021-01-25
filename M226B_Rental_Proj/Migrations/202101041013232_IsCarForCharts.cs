namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCarForCharts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsCar", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "RentTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RentTime", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "IsCar");
        }
    }
}
