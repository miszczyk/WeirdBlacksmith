namespace WeirdBlacksmith.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newest1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeaponsModelsTitleModels", "WeaponsModels_Id", "dbo.WeaponsModels");
            DropForeignKey("dbo.WeaponsModelsTitleModels", "TitleModels_Id", "dbo.TitleModels");
            DropIndex("dbo.WeaponsModelsTitleModels", new[] { "WeaponsModels_Id" });
            DropIndex("dbo.WeaponsModelsTitleModels", new[] { "TitleModels_Id" });
            DropPrimaryKey("dbo.TitleModels");
            AddColumn("dbo.TitleModels", "WeaponsModels_Id", c => c.Long());
            AlterColumn("dbo.TitleModels", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.WeaponsModels", "TitleModelsId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TitleModels", "Id");
            CreateIndex("dbo.TitleModels", "WeaponsModels_Id");
            AddForeignKey("dbo.TitleModels", "WeaponsModels_Id", "dbo.WeaponsModels", "Id");
            DropTable("dbo.WeaponsModelsTitleModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WeaponsModelsTitleModels",
                c => new
                    {
                        WeaponsModels_Id = c.Long(nullable: false),
                        TitleModels_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.WeaponsModels_Id, t.TitleModels_Id });
            
            DropForeignKey("dbo.TitleModels", "WeaponsModels_Id", "dbo.WeaponsModels");
            DropIndex("dbo.TitleModels", new[] { "WeaponsModels_Id" });
            DropPrimaryKey("dbo.TitleModels");
            AlterColumn("dbo.WeaponsModels", "TitleModelsId", c => c.Long(nullable: false));
            AlterColumn("dbo.TitleModels", "Id", c => c.Long(nullable: false, identity: true));
            DropColumn("dbo.TitleModels", "WeaponsModels_Id");
            AddPrimaryKey("dbo.TitleModels", "Id");
            CreateIndex("dbo.WeaponsModelsTitleModels", "TitleModels_Id");
            CreateIndex("dbo.WeaponsModelsTitleModels", "WeaponsModels_Id");
            AddForeignKey("dbo.WeaponsModelsTitleModels", "TitleModels_Id", "dbo.TitleModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WeaponsModelsTitleModels", "WeaponsModels_Id", "dbo.WeaponsModels", "Id", cascadeDelete: true);
        }
    }
}
