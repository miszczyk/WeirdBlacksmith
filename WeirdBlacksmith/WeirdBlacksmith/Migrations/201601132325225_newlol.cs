namespace WeirdBlacksmith.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newlol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponsModelsTitleModels",
                c => new
                    {
                        WeaponsModels_Id = c.Long(nullable: false),
                        TitleModels_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.WeaponsModels_Id, t.TitleModels_Id })
                .ForeignKey("dbo.WeaponsModels", t => t.WeaponsModels_Id, cascadeDelete: true)
                .ForeignKey("dbo.TitleModels", t => t.TitleModels_Id, cascadeDelete: true)
                .Index(t => t.WeaponsModels_Id)
                .Index(t => t.TitleModels_Id);
            
            AddColumn("dbo.TitleModels", "AspNetUsersId", c => c.String());
            AddColumn("dbo.WeaponsModels", "TitleModelsId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeaponsModelsTitleModels", "TitleModels_Id", "dbo.TitleModels");
            DropForeignKey("dbo.WeaponsModelsTitleModels", "WeaponsModels_Id", "dbo.WeaponsModels");
            DropIndex("dbo.WeaponsModelsTitleModels", new[] { "TitleModels_Id" });
            DropIndex("dbo.WeaponsModelsTitleModels", new[] { "WeaponsModels_Id" });
            DropColumn("dbo.WeaponsModels", "TitleModelsId");
            DropColumn("dbo.TitleModels", "AspNetUsersId");
            DropTable("dbo.WeaponsModelsTitleModels");
        }
    }
}
