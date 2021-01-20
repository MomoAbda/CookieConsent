using System.Collections.Generic;


namespace CookieConsent.CookiesConsent.Abstraction
{
    public interface ICookies
    {
        IEnumerable<CookiesGroup> Groups { get; }
    }

}
