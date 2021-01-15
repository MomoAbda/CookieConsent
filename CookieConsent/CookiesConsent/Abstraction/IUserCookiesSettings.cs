using System.Collections.Generic;

namespace CookieConsent
{
    public interface IUserCookiesSettings
    {
        Dictionary<ICookiesGroup, bool> GroupsConsent { get; }
        bool IsConsented(ICookiesGroup cookiesGroup);
        ICookiesGroup GetGroupByName(string name);
    }
}
