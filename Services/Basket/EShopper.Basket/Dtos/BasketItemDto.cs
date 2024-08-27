﻿namespace EShopper.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
