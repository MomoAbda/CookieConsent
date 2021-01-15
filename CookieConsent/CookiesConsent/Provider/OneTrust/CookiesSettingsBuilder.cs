using CookieConsent.CookiesConsent.Abstraction;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class CookiesSettingsBuilder : ICookiesSettingsBuilder
    {
        private const string ONETRUST_COOKIENAME = "OptanonConsent";
        private IHttpContextAccessor _httpContextAccessor;

        public CookiesSettingsBuilder(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IUserCookiesSettings Build()
        {
            var oneTrustCookies = GetOneTrustCookiesValue();

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

        private string GetOneTrustCookiesValue()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[ONETRUST_COOKIENAME];
        }
    }
}
