namespace GameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameIdAndOrderIdInOrderClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "game_Id", "dbo.Games");
            DropForeignKey("dbo.Orders", "player_Id", "dbo.Players");
            DropIndex("dbo.Orders", new[] { "game_Id" });
            DropIndex("dbo.Orders", new[] { "player_Id" });
            RenameColumn(table: "dbo.Orders", name: "game_Id", newName: "gameid");
            RenameColumn(table: "dbo.Orders", name: "player_Id", newName: "playerid");
            AlterColumn("dbo.Orders", "gameid", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "playerid", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "gameid");
            CreateIndex("dbo.Orders", "playerid");
            AddForeignKey("dbo.Orders", "gameid", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "playerid", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "playerid", "dbo.Players");
            DropForeignKey("dbo.Orders", "gameid", "dbo.Games");
            DropIndex("dbo.Orders", new[] { "playerid" });
            DropIndex("dbo.Orders", new[] { "gameid" });
            AlterColumn("dbo.Orders", "playerid", c => c.Int());
            AlterColumn("dbo.Orders", "gameid", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "playerid", newName: "player_Id");
            RenameColumn(table: "dbo.Orders", name: "gameid", newName: "game_Id");
            CreateIndex("dbo.Orders", "player_Id");
            CreateIndex("dbo.Orders", "game_Id");
            AddForeignKey("dbo.Orders", "player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Orders", "game_Id", "dbo.Games", "Id");
        }
    }
}
