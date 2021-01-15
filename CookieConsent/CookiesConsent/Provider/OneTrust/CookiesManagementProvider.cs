using CookieConsent.CookiesConsent.Abstraction;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class CookiesManagementProvider : BaseCookiesManagementProvider
    {
        public override string Name => "OneTrust";

        public CookiesManagementProvider(CookiesSettingsBuilder cookiesSettingsBuilder) : base(cookiesSettingsBuilder)
        {
        }
    }
}
