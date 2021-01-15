using CookieConsent.CookiesConsent.Abstraction;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class CookiesSettingsBuilder : ICookiesSettingsBuilder
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CookiesSettingsBuilder(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IUserCookiesSettings Build()
        {
            Dictionary<ICookiesGroup, bool> settings = new Dictionary<ICookiesGroup, bool>()
                {
                     {
                        new CookiesGroup("BookMe",new List<ICookies>{new Cookies("BookMeCookie") }),true
                    },
                      {
                        new CookiesGroup("Vouchers",new List<ICookies>{new Cookies("VoucherCookie") }),false
                    }
                   };

            return new UserCookiesSettings(settings);
        }
    }
}
