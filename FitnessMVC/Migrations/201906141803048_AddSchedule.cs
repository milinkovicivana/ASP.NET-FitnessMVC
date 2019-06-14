namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        Time = c.String(nullable: false, maxLength: 7),
                        ProgramId = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Schedules", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Schedules", new[] { "InstructorId" });
            DropIndex("dbo.Schedules", new[] { "ProgramId" });
            DropTable("dbo.Schedules");
        }
    }
}
