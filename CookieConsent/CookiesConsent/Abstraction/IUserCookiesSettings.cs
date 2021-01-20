using CookieConsent.CookiesConsent;

namespace CookieConsent
{
    public interface IUserCookiesSettings
    {
        bool IsConsented(string groupName);
    }
}
