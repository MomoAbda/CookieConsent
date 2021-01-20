namespace CookieConsent.CookiesConsent
{
    public class CookiesGroup
    {
        public string Name { get; }

        public bool IsEnable { get; }

        public CookiesGroup(string name, bool isEnable)
        {
            Name = name;
            IsEnable = isEnable;
        }
    }
}
