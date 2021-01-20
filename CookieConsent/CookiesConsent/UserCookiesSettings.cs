using CookieConsent.CookiesConsent.Abstraction;
using System;
using System.Linq;

namespace CookieConsent.CookiesConsent
{
    public abstract class UserCookiesSettings : IUserCookiesSettings
    {
        public ICookies _cookies { get; }

        public UserCookiesSettings(ICookies cookies)
        {
            if (cookies == null)
                throw new ArgumentException("cookies parameter must be not null");

            _cookies = cookies;
        }

        public bool IsConsented(string groupName)
        {
            var group = _cookies.Groups.FirstOrDefault(p => p.Name == groupName);
            
            if(group != null)
                return group.IsEnable;

            return false;
        }
    }
}
