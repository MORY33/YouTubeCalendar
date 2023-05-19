namespace YouTubeOfficial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigrationName1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ThumbnailUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
        }
    }
}
