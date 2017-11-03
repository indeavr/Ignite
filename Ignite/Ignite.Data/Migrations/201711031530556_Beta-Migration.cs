namespace Ignite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DueDate = c.DateTime(nullable: false),
                        DateOfAssignment = c.DateTime(nullable: false),
                        Type = c.String(nullable: false),
                        State = c.String(nullable: false),
                        TestResult = c.Decimal(precision: 18, scale: 2),
                        DateOfCompletion = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        RequiredScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Assignments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "UserId" });
            DropIndex("dbo.Assignments", new[] { "CourseId" });
            DropColumn("dbo.AspNetUsers", "Department");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
