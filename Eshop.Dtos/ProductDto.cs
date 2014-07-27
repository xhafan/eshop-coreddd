﻿using CoreDdd.Nhibernate;

namespace Eshop.Dtos
{
    public class ProductDto : IAutoMappedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}