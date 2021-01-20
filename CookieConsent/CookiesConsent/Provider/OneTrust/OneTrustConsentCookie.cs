using CookieConsent.CookiesConsent.Abstraction;
using System.Collections.Generic;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class OneTrustConsentCookie : ICookies
    {
        public IEnumerable<CookiesGroup> Groups { get; }

        public OneTrustConsentCookie(IEnumerable<CookiesGroup> groups)
        {
            Groups = groups;
        }
    }
}
