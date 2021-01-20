using CookieConsent.CookiesConsent.Abstraction;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class OneTrustUserCookiesSettings : UserCookiesSettings
    {
        public OneTrustUserCookiesSettings(ICookies cookies) : base(cookies)
        {
        }
    }
}
