using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Game game { get; set; }
        public int gameid { get; set; }
        public Player player { get; set; }
        public int playerid { get; set; }
        public float DiscountPrice { get; set; }
    }
}