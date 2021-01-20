using CookieConsent.CookiesConsent.Abstraction;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class OneTrustCookiesSettingsBuilder : ICookiesSettingsBuilder
    {
        private readonly IOneTrustConsentCookieFactory _optanonConsentCookieFactory;
        public OneTrustCookiesSettingsBuilder(IOneTrustConsentCookieFactory optanonConsentCookieFactory)
        {
            _optanonConsentCookieFactory = optanonConsentCookieFactory;
        }

        public IUserCookiesSettings Build()
        {
            var optanonConsentCookie = _optanonConsentCookieFactory.Create();

            return new OneTrustUserCookiesSettings(optanonConsentCookie);
        }
    }
}
