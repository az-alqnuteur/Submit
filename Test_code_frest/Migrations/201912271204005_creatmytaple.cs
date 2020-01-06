namespace Test_code_frest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatmytaple : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserNamr = c.String(),
                        UserPass = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
