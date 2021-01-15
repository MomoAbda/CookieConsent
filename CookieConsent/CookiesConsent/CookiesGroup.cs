using System.Collections.Generic;

namespace CookieConsent.CookiesConsent
{
    public class CookiesGroup : ICookiesGroup
    {
        public string Name { get; }

        public IEnumerable<ICookies> Cookies { get; }

        public CookiesGroup(string name, IEnumerable<ICookies> cookies)
        {
            Name = name;
            Cookies = cookies;
        }
    }
}
