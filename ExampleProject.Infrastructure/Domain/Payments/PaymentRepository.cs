﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampleProject.Domain.Payments;
using ExampleProject.Infrastructure.Database;

namespace ExampleProject.Infrastructure.Domain.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OrdersContext _context;

        public PaymentRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Payment> GetByIdAsync(PaymentId id)
        {
            return await this._context.Payments
                .SingleAsync(x => x.Id == id);
        }

        public async Task AddAsync(Payment payment)
        {
            await this._context.Payments.AddAsync(payment);
        }
    }
}