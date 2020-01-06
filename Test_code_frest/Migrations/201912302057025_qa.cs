namespace Test_code_frest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TapleReseetpasswords",
                c => new
                    {
                        RestPassword_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Code_send = c.String(),
                    })
                .PrimaryKey(t => t.RestPassword_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TapleReseetpasswords");
        }
    }
}
