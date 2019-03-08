using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace ThridPartyLogin_AspNetCore
{
    public static class ThridPartyLoginExtensions
    {
        public static IServiceCollection AddWeChatLogin(this IServiceCollection services, Action<CredentialSetting> action = null)
        {

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (action!=null)
            {
                services.Configure(action);
            }
            services.TryAddTransient<ILogin, WeChatLogin>();
            return services;
        }

        public static IServiceCollection AddQqLogin(this IServiceCollection services, Action<CredentialSetting> action = null)
        {
            if (services==null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (action != null)
            {
                services.Configure(action);
            }
            services.TryAddTransient<ILogin, QqLogin>();
            return services;
        }
    }
}