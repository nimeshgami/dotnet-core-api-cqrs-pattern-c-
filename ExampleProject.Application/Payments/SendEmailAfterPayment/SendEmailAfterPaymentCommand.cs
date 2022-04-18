using System;
using MediatR;
using Newtonsoft.Json;
using ExampleProject.Application.Configuration.Commands;
using ExampleProject.Domain.Payments;

namespace ExampleProject.Application.Payments.SendEmailAfterPayment
{
    public class SendEmailAfterPaymentCommand : InternalCommandBase<Unit>
    {
        public PaymentId PaymentId { get; }

        [JsonConstructor]
        public SendEmailAfterPaymentCommand(Guid id, PaymentId paymentId) : base(id)
        {
            this.PaymentId = paymentId;
        }
    }
}