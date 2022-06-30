namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogImage2", c => c.String());
            AddColumn("dbo.Blogs", "BlogImage3", c => c.String());
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryDescription");
            DropColumn("dbo.Blogs", "BlogImage3");
            DropColumn("dbo.Blogs", "BlogImage2");
        }
    }
}
