namespace One.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEntityOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentOrder");
        }
    }
}
