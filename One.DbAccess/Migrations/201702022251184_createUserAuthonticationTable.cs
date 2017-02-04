namespace One.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createUserAuthonticationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAuthontication",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAuthontication");
        }
    }
}
