using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using ThridPartyLogin_AspNetCore.Common;
using ThridPartyLogin_AspNetCore.IService;
using ThridPartyLogin_AspNetCore.Service;

namespace ThridPartyLogin_AspNetCore
{
    public static class ThridPartyLoginExtensions
    {
        public static IServiceCollection AddWeChatLogin(this IServiceCollection services, Action<CredentialSetting> credential = null)
        {
           
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IWeChatLogin, WeChatLogin>();
            return services;
        }

        public static IServiceCollection AddQqLogin(this IServiceCollection services, Action<CredentialSetting> credential = null)
        {
            if (services==null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<IQqLogin, QqLogin>();
            return services;
        }
        public static IServiceCollection AddSinaLogin(this IServiceCollection services, Action<CredentialSetting> credential = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<ISinaLogin, SinaLogin>();
            return services;
        }
    }
}