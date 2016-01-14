namespace WeirdBlacksmith.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponsModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Rarity = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 22),
                        Description = c.String(maxLength: 200),
                        MinDamage = c.Int(nullable: false),
                        MaxDamage = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        Added = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeaponsModels");
        }
    }
}
