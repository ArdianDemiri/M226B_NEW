namespace M226B_Rental_Proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarLKWW : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Seats", c => c.Int());
            AddColumn("dbo.Vehicles", "License", c => c.String());
            AddColumn("dbo.Vehicles", "MaxWeight", c => c.Int());
            AddColumn("dbo.Vehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Discriminator");
            DropColumn("dbo.Vehicles", "MaxWeight");
            DropColumn("dbo.Vehicles", "License");
            DropColumn("dbo.Vehicles", "Seats");
        }
    }
}
