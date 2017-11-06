namespace Ignite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Content = c.Binary(nullable: false),
                        Order = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "CourseId", "dbo.Courses");
            DropIndex("dbo.Images", new[] { "CourseId" });
            DropTable("dbo.Images");
        }
    }
}
