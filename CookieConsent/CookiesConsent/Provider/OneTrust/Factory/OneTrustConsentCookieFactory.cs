using CookieConsent.CookiesConsent.Abstraction;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace CookieConsent.CookiesConsent.Provider.OneTrust
{
    public class OneTrustConsentCookieFactory : IOneTrustConsentCookieFactory
    {
        private const string ONETRUST_COOKIENAME = "OptanonConsent";

        private IHttpContextAccessor _httpContextAccessor;

        public OneTrustConsentCookieFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public OneTrustConsentCookie Create()
        {
            var defaultOptanonConsentCookie = new OneTrustConsentCookie(new List<CookiesGroup>());

            if (IsOneTrustCookiesAvailable())
            {
                var cookiesValuesDictionnary = GetCookiesValueDictionnary();
                var cookiesGroup = GetGroups();

                var optanonConsentCookie = new OneTrustConsentCookie(cookiesGroup);
                return optanonConsentCookie;
            }
            else
            {
                return defaultOptanonConsentCookie;
            }
        }
        private string GetRawCookieValue()
        {
            var rawCookieValue = _httpContextAccessor.HttpContext.Request.Cookies[ONETRUST_COOKIENAME];
            return rawCookieValue ?? string.Empty;

        }

        /// <summary>
        /// Get a NameValueCollection
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetCookiesValueDictionnary()
        {
            var rawCookieValue = GetRawCookieValue();
            var pairs = rawCookieValue.Split("&");
            var cookiesValues = new Dictionary<string, string>();

            foreach (var item in pairs)
            {
                var key = item.Split("=")[0];
                var value = item.Split("=")[1];

                if (!cookiesValues.ContainsKey(key))
                    cookiesValues.Add(key, value);
            }

            return cookiesValues;
        }

        private IEnumerable<CookiesGroup> GetGroups()
        {
            var cookiesValues = GetCookiesValueDictionnary();

            var allGroups = cookiesValues["groups"].Split(",").ToList();
            List<CookiesGroup> allCookiesGroup = new List<CookiesGroup>();
            foreach (var groups in allGroups)
            {
                var groupId = groups.Split(":")[0];
                var groupValue = groups.Split(":")[1];

                bool groupIsEnable = groupValue == "1";
                var cookiesGroup = new CookiesGroup(groupId, groupIsEnable);

                allCookiesGroup.Add(cookiesGroup);
            }

            return allCookiesGroup;
        }

        private bool IsOneTrustCookiesAvailable()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(ONETRUST_COOKIENAME);
        }
    }
}
