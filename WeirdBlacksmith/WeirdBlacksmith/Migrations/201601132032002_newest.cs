namespace WeirdBlacksmith.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TitleModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OwnedBy = c.String(),
                        Title = c.String(),
                        CurrentUserRole = c.String(),
                        WeaponsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TitleModels");
        }
    }
}
