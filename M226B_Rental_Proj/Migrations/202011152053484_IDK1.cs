namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDK1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "StartTime");
        }
    }
}
