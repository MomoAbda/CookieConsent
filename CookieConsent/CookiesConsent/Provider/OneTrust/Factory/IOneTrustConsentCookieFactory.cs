using CookieConsent.CookiesConsent.Provider.OneTrust;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;

namespace CookieConsent.CookiesConsent.Abstraction
{
    public interface IOneTrustConsentCookieFactory
    {
        OneTrustConsentCookie Create();
    }
}
