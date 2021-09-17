namespace KoruSigorta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Randevus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        PolicyNo = c.Int(nullable: false),
                        TcNo = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        District = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Approval = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Randevus");
        }
    }
}
