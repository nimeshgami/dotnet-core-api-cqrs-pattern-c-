﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampleProject.Domain.Products;
using ExampleProject.Infrastructure.Database;
using ExampleProject.Infrastructure.SeedWork;

namespace ExampleProject.Infrastructure.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrdersContext _context;
        public ProductRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Product>> GetByIdsAsync(List<ProductId> ids)
        {
            return await this._context
                .Products
                .IncludePaths("_prices")
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await this._context
                .Products
                .IncludePaths("_prices")
                .ToListAsync();
        }
    }
}