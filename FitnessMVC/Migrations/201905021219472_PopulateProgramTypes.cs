namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProgramTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.ProgramTypes (Id, Name, Description) VALUES (1, N'Fitnes programi u teretani', null)");
            Sql("INSERT INTO dbo.ProgramTypes (Id, Name, Description) VALUES (2, N'Grupni fitnes programi', null)");
            Sql("INSERT INTO dbo.ProgramTypes (Id, Name, Description) VALUES (3, N'Spa programi', null)");
        }
        
        public override void Down()
        {
        }
    }
}
