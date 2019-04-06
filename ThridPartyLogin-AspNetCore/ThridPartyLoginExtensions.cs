using System;
using Microsoft.Extensions.DependencyInjection;
using ThridPartyLogin_AspNetCore.Entity;
using ThridPartyLogin_AspNetCore.IService;
using ThridPartyLogin_AspNetCore.Service;

namespace ThridPartyLogin_AspNetCore
{
    public static class ThridPartyLoginExtensions
    {
        public static IServiceCollection AddWeChatLogin(this IServiceCollection services,
            Action<WechatCredential> credential = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.Configure(credential);
            services.AddScoped<IWeChatLogin, WeChatLogin>();
            return services;
        }

        public static IServiceCollection AddQqLogin(this IServiceCollection services,
            Action<QQCredential> credential = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.Configure(credential);
            services.AddScoped<IQqLogin, QqLogin>();
            return services;
        }

        public static IServiceCollection AddSinaLogin(this IServiceCollection services,
            Action<WeiBoCredential> credential = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.Configure(credential);
            services.AddScoped<ISinaLogin, WeiBoLogin>();
            return services;
        }

        public static IServiceCollection AddFackbookLogin(this IServiceCollection services,
            Action<FaceBookCredential> credential = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.Configure(credential);
            services.AddScoped<IFacebookLogin, FacebookLogin>();
            return services;
        }

        public static IServiceCollection AddGitHubLogin(this IServiceCollection services,
            Action<GitHubCredential> credential = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.Configure(credential);
            services.AddScoped<IGitHubLogin, GitHubLogin>();
            return services;
        }
    }
}