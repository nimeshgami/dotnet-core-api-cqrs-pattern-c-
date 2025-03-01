﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExampleProject.Domain.SeedWork;
using ExampleProject.Domain.SharedKernel;

namespace ExampleProject.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public ProductId Id { get; private set; }

        public string Name { get; private set; }

        private List<ProductPrice> _prices;

        private Product()
        {

        }
    }
}