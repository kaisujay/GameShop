using GameShop.Dtos;
using GameShop.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace GameShop.Controllers.WebAPI
{
    public class OrdersController : ApiController
    {
        //GET : /Api/Orders/
        [HttpGet]
        public List<OrderDto> GetOrder()
        {
            using (GameShopDBContext gameShopDBContext=new GameShopDBContext())
            {
                var AllOrders = gameShopDBContext.Orders.Include(x => x.game).Include(x => x.player)
                                        .Select(x => new OrderDto()
                                        {
                                            Id = x.Id,
                                            GameName = x.game.GameName,
                                            PlayerName = x.player.PlayerName,
                                            DiscountPrice = x.DiscountPrice,
                                            Email = x.player.Email,
                                            Price = x.game.Price,
                                            Phone = x.player.Phone,
                                            ReleaseDate = x.game.ReleaseDate
                                        })
                                        .ToList();
                return AllOrders;
            }                        
        }

        //GET : /Api/Orders/id
        [HttpGet]
        public OrderDto GetOrder(int id)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var OneOrder = gameShopDBContext.Orders.Include(x => x.game).Include(x => x.player)
                                        .Select(x => new OrderDto()
                                        {
                                            Id = x.Id,
                                            GameName = x.game.GameName,
                                            PlayerName = x.player.PlayerName,
                                            DiscountPrice = x.DiscountPrice,
                                            Email = x.player.Email,
                                            Price = x.game.Price,
                                            Phone = x.player.Phone,
                                            ReleaseDate = x.game.ReleaseDate
                                        })
                                        .SingleOrDefault(x => x.Id == id);
                return OneOrder;
            }
        }

        //POST : /Api/Orders/
        [HttpPost]
        public CreateOrderDto CreateOrder([FromBody]CreateOrderDto orderDto)
        {
            using (GameShopDBContext gameShopDBContext = new GameShopDBContext())
            {
                var GameId = gameShopDBContext.Games                              
                                .Where(x => x.GameName == orderDto.GameName)
                               .Select(x => x.Id).FirstOrDefault();

               var PlayerId = gameShopDBContext.Players                               
                                .Where(x => x.PlayerName == orderDto.PlayerName)
                                .Select(x => x.Id).FirstOrDefault();

                Order SaveOrder = new Order();
                SaveOrder.gameid = GameId;
                SaveOrder.playerid = PlayerId;
                SaveOrder.DiscountPrice = orderDto.DiscountPrice;

                gameShopDBContext.Orders.Add(SaveOrder);
                gameShopDBContext.SaveChanges();

                orderDto.Id = SaveOrder.Id;

                return orderDto;                
            }
        }
    }
}
