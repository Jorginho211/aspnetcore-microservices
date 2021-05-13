using System;
using System.Collections.Generic;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existsProduct = productCollection.Find(p => true).Any();
            if (!existsProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>() 
            {
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "Summary",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Category = "Smart Phone",
                    ImageFile = "product-1.png",
                    Price = 950.00M
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Summary = "Summary",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Category = "Smart Phone",
                    ImageFile = "product-2.png",
                    Price = 840.00M
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Summary = "Summary",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Category = "White Appliances",
                    ImageFile = "product-3.png",
                    Price = 650.00M
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Summary = "Summary",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Category = "White Appliances",
                    ImageFile = "product-4.png",
                    Price = 470.00M
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Summary = "Summary",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Category = "Smart Phone",
                    ImageFile = "product-5.png",
                    Price = 380.00M
                },
                new Product()
                {
                    Name = "LG G7 ThinQ",
                    Summary = "Summary",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Category = "Home Kitchen",
                    ImageFile = "product-6.png",
                    Price = 240.00M
                },
            };
        }
    }
}