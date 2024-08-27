﻿namespace EShopper.WebUI.Dtos.CatalogDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
