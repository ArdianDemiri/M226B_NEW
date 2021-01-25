namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IstakenCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsTaken", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsTaken");
        }
    }
}
