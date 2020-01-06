namespace Test_code_frest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requrd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserNamr", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserPass", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserEmail", c => c.String());
            AlterColumn("dbo.Users", "UserPass", c => c.String());
            AlterColumn("dbo.Users", "UserNamr", c => c.String());
        }
    }
}
