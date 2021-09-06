using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Service.Infra.Shared;
using Service.Infra.Users;
using Service.Application.Users.Commands.CreateUser;
using Service.Domain.Users.Entities;
using Service.Domain.Users.Events;
using Service.Application.Users.EventHandlers;
using Service.Application.Shared.Middlewares;
using FluentValidation;

namespace UserWebApi.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
