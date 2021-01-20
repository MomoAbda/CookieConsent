using CookieConsent.CookiesConsent.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCookiesOneTrustProvider(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.TryAddSingleton<ICookiesManagementProvider, OneTrustCookiesManagementProvider>();
            services.TryAddSingleton<OneTrustCookiesSettingsBuilder>();
            services.TryAddSingleton<IOneTrustConsentCookieFactory, OneTrustConsentCookieFactory>();

            return services;
        }
    }
}
