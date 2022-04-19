using Comp.ProductManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Product A",
                    ProductDescription = "Product A Description",
                    Price = 1500
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Product B",
                    ProductDescription = "Product B Description",
                    Price = 4500
                }
            );
        }
    }
}
