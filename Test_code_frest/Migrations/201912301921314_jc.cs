namespace Test_code_frest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "NewPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "NewPassword", c => c.String());
        }
    }
}
