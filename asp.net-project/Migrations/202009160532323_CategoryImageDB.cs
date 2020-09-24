namespace asp.net_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryImageDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Image", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "ImageSource", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageSource");
            DropColumn("dbo.Categories", "Image");
        }
    }
}
