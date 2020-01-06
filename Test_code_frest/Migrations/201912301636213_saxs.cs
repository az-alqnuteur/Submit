namespace Test_code_frest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saxs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserDetails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserDetails");
        }
    }
}
