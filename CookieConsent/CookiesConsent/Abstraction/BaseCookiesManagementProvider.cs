namespace CookieConsent.CookiesConsent.Abstraction
{
    public interface ICookiesManagementProvider
    {
        string Name { get; }
        public IUserCookiesSettings GetCurrentUserCookiesSettings();

    }
    public abstract class BaseCookiesManagementProvider : ICookiesManagementProvider
    {
        public abstract string Name { get; }
        protected ICookiesSettingsBuilder _cookiesSettingsBuilder;

        public IUserCookiesSettings GetCurrentUserCookiesSettings()
        {
            return _cookiesSettingsBuilder.Build();
        }

        public BaseCookiesManagementProvider(ICookiesSettingsBuilder cookiesSettingsBuilder)
        {
            _cookiesSettingsBuilder = cookiesSettingsBuilder;
        }
    }
}
