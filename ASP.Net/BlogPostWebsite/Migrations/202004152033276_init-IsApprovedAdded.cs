namespace BlogPostWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initIsApprovedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsApproved");
        }
    }
}
