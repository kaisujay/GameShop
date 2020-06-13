using GameShop.Dtos;
using GameShop.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace GameShop.Controllers.WebAPI
{
    public class PlayersController : ApiController
    {
        //GET : /API/Players/
        [HttpGet]
        public List<PlayerDto> GetPlayer()
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var AllPlayers = gameShopDBContext.Players
                                        .Select(x => new PlayerDto()
                                        {
                                            Id = x.Id,
                                            PlayerName = x.PlayerName,
                                            Email = x.Email,
                                            Phone = x.Phone,
                                            BirthDate = x.BirthDate,
                                            Gender = x.Gender
                                        }).ToList();
                return AllPlayers;
            }
        }

        //GET : /API/Players/id
        [HttpGet]
        public PlayerDto GetPlayer(int id)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var OnePlayer = gameShopDBContext.Players
                                         .Select(x => new PlayerDto()
                                         {
                                             Id = x.Id,
                                             PlayerName = x.PlayerName,
                                             Email = x.Email,
                                             Phone = x.Phone,
                                             BirthDate = x.BirthDate,
                                             Gender = x.Gender
                                         })
                                         .SingleOrDefault(x => x.Id == id);
                return OnePlayer;
            }
        }

        //GET : /API/Players/id
        [HttpGet]
        [Route("Api/Players/{playername:alpha}")]
        public Player GetPlayer(string playername)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var OnePlayer = gameShopDBContext.Players.SingleOrDefault(x => x.PlayerName == playername);
                return OnePlayer;
            }
        }

        //POST : /API/Players/
        [HttpPost]
        public CreatePlayerDto CreatePlayer([FromBody]CreatePlayerDto playerDto)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                Player player = new Player();
                player.PlayerName = playerDto.PlayerName;
                player.Email = playerDto.Email;
                player.Phone = playerDto.Phone;
                player.BirthDate = playerDto.BirthDate;
                player.Gender = playerDto.Gender;
                player.Password = playerDto.Password;

                gameShopDBContext.Players.Add(player);
                gameShopDBContext.SaveChanges();

                return playerDto;
            }
        }
    }
}
