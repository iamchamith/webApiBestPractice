namespace One.Test.Mockdata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(nullable: false),
                        ExceptionStackTrace = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        CreatedUser = c.String(),
                        ExceptionType = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        Descripton = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Error");
        }
    }
}
