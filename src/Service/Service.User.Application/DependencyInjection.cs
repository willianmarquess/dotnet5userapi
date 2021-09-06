using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Service.Application.Users.Commands.CreateUser;
using Service.Domain.Users.Entities;
using Service.Domain.Users.Events;
using Service.Application.Users.EventHandlers;
using Service.Application.Shared.Middlewares;
using Service.Application.Users.Queries.GetAllUsers;
using System.Collections.Generic;
using Service.Application.Users.Queries.GetUserById;
using Service.Application.Users.Commands.UpdateUser;

namespace Service.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationMiddleware<,>));

            return services;
        }
    }
}
