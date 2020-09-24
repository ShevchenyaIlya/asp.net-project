namespace asp.net_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotRequiredImageUrl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ImageUrl", c => c.String(nullable: false));
        }
    }
}
