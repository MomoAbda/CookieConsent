using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieConsent
{
    public interface ICookiesGroup
    {
        string Name { get; }
        IEnumerable<ICookies> Cookies { get; }
    }
}
