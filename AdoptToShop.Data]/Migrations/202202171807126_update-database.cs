namespace AdoptToShop.Data_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopter", "Contact", c => c.String(nullable: false));
            AddColumn("dbo.Animal", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animal", "Name");
            DropColumn("dbo.Adopter", "Contact");
        }
    }
}
