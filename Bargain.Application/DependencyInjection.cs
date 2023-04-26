using Bargain.Application.Interfaces;
using Bargain.Application.Services;
using Bargain.Application.ViewModels.Item;
using Bargain.Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IShopService, ShopService>();



            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
