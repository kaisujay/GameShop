using GameShop.Dtos;
using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameShop.Controllers.WebAPI
{
    public class GamesController : ApiController
    {
        //GET : /API/Games/
        [HttpGet]
        public List<GameDto> GetGame()
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var games = gameShopDBContext.Games
                                  .Select(x => new GameDto()
                                  {
                                      Id = x.Id,
                                      GameName = x.GameName,
                                      Publisher = x.Publisher,
                                      GameType = x.GameType,
                                      ReleaseDate = x.ReleaseDate,
                                      PlayTime = x.PlayTime,
                                      Price = x.Price                                  
                                  }).ToList();
                return games;
            }
        }

        //GET : /API/Games/id
        [HttpGet]
        public GameDto GetGame(int id)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var OneGame = gameShopDBContext.Games
                                        .Select(x => new GameDto()
                                        {
                                            Id = x.Id,
                                            GameName = x.GameName,
                                            Publisher = x.Publisher,
                                            GameType = x.GameType,
                                            ReleaseDate = x.ReleaseDate,
                                            PlayTime = x.PlayTime,
                                            Price = x.Price
                                        })
                                        .SingleOrDefault(x =>x.Id == id);
                return OneGame;
            }
        }

        //POST : /API/Games/
        [HttpPost]
        public GameDto CreateGame([FromBody]GameDto gameDto)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                Game game = new Game();
                game.GameName = gameDto.GameName;
                game.GameType = gameDto.GameType;
                game.PlayTime = gameDto.PlayTime;
                game.Publisher = gameDto.Publisher;
                game.ReleaseDate = gameDto.ReleaseDate;
                game.Price = gameDto.Price;

                gameShopDBContext.Games.Add(game);
                gameShopDBContext.SaveChanges();

                return gameDto;
            }
        }
    }
}
