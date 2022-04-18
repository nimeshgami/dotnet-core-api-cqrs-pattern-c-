﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ExampleProject.Domain.Customers.Orders;
using ExampleProject.Domain.Payments;
using ExampleProject.Infrastructure.Database;

namespace ExampleProject.Infrastructure.Domain.Payments
{
    internal sealed class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments", SchemaNames.Payments);
            
            builder.HasKey(b => b.Id);

            builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
            builder.Property<OrderId>("_orderId").HasColumnName("OrderId");
            builder.Property("_status").HasColumnName("StatusId").HasConversion(new EnumToNumberConverter<PaymentStatus, byte>());
            builder.Property<bool>("_emailNotificationIsSent").HasColumnName("EmailNotificationIsSent");
        }
    }
}