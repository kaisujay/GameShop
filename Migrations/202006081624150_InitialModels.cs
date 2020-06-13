namespace GameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        Publisher = c.String(),
                        PlayTime = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        GameType = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscountPrice = c.Single(nullable: false),
                        game_Id = c.Int(),
                        player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.game_Id)
                .ForeignKey("dbo.Players", t => t.player_Id)
                .Index(t => t.game_Id)
                .Index(t => t.player_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "player_Id", "dbo.Players");
            DropForeignKey("dbo.Orders", "game_Id", "dbo.Games");
            DropIndex("dbo.Orders", new[] { "player_Id" });
            DropIndex("dbo.Orders", new[] { "game_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Orders");
            DropTable("dbo.Games");
        }
    }
}
