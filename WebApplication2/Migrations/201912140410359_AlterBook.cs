namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GanreId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "GanreId");
        }
    }
}
