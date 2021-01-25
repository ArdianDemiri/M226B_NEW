namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNUllable2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "StartTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
