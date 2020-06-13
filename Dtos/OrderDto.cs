using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public Int64 Phone { get; set; }
        public float Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float DiscountPrice { get; set; }
    }
}