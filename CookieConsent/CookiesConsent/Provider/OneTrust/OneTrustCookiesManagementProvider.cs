using CookieConsent.CookiesConsent.Abstraction;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class OneTrustCookiesManagementProvider : BaseCookiesManagementProvider
    {
        public override string Name => "OneTrust";

        public OneTrustCookiesManagementProvider(OneTrustCookiesSettingsBuilder cookiesSettingsBuilder) : base(cookiesSettingsBuilder)
        {
        }
    }
}
