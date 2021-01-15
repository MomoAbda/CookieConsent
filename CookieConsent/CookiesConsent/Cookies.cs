namespace CookieConsent.CookiesConsent
{
    public class Cookies : ICookies
    {
        public string Name { get; }

        public Cookies(string name)
        {
            Name = name;
        }
    }
}
