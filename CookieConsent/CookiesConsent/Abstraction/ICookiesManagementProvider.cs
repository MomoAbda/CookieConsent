namespace CookieConsent.CookiesConsent.Abstraction
{
    public interface ICookiesManagementProvider
    {
        string Name { get; }
        public IUserCookiesSettings GetCurrentUserCookiesSettings();

    }
}
