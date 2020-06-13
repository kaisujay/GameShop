using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Dtos
{
    public class CreateOrderDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string PlayerName { get; set; }
        public float DiscountPrice { get; set; }
    }
}