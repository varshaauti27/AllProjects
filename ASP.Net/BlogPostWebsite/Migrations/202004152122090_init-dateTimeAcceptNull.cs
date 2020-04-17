namespace BlogPostWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdateTimeAcceptNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
