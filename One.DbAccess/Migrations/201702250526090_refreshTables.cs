namespace One.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubject", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSubject", "StudentId", "dbo.Subject");
            DropIndex("dbo.StudentSubject", new[] { "StudentId" });
            CreateTable(
                "dbo.School",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Student", "SchoolId", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "StreemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "SchoolId");
            CreateIndex("dbo.Student", "StreemId");
            AddForeignKey("dbo.Student", "SchoolId", "dbo.School", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Student", "StreemId", "dbo.Streem", "Id", cascadeDelete: true);
            DropTable("dbo.StudentSubject");
            DropTable("dbo.Subject");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentSubject",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SubjectId });
            
            DropForeignKey("dbo.Student", "StreemId", "dbo.Streem");
            DropForeignKey("dbo.Student", "SchoolId", "dbo.School");
            DropIndex("dbo.Student", new[] { "StreemId" });
            DropIndex("dbo.Student", new[] { "SchoolId" });
            DropColumn("dbo.Student", "StreemId");
            DropColumn("dbo.Student", "SchoolId");
            DropTable("dbo.Streem");
            DropTable("dbo.School");
            CreateIndex("dbo.StudentSubject", "StudentId");
            AddForeignKey("dbo.StudentSubject", "StudentId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubject", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
        }
    }
}
