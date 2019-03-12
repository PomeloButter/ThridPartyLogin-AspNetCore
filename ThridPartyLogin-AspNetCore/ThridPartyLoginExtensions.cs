using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

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

            services.BuildServiceProvider().GetService<IHttpContextAccessor>();
            services.AddScoped<ILogin, WeChatLogin>();
            return services;
        }

        public static IServiceCollection AddQqLogin(this IServiceCollection services, IHttpContextAccessor httpContextAccessor, CredentialSetting action = null)
        {
            if (services==null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services;
        }

    }
}