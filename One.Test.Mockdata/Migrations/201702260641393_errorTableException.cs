namespace One.Test.Mockdata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorTableException : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Error", "Exception", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Error", "Exception");
        }
    }
}
