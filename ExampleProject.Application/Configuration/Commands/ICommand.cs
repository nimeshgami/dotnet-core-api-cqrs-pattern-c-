﻿using System;
using MediatR;

namespace ExampleProject.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
        Guid Id { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}