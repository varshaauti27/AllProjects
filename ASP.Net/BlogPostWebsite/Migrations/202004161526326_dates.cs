namespace BlogPostWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ExpirationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ExpirationDate");
        }
    }
}
