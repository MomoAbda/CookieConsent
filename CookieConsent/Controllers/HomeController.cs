using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CookieConsent.Models;
using CookieConsent.CookiesConsent.Abstraction;

namespace CookieConsent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICookiesManagementProvider _cookiesManagementProvider;

        public HomeController(ILogger<HomeController> logger, ICookiesManagementProvider cookiesManagementProvider)
        {
            _logger = logger;
            _cookiesManagementProvider = cookiesManagementProvider;
        }

        public IActionResult Index()
        {

            //var bookmeCookiesGroup = settings.GetGroupByName("BookMe");
            //var isBookMeCookiesGroupConsented = settings.IsConsented(bookmeCookiesGroup);

            //var voucherCookiesGroup = settings.GetGroupByName("Vouchers");
            //var isVoucherCookiesGroupConsented = settings.IsConsented(voucherCookiesGroup);

            //if (isBookMeCookiesGroupConsented)
            //    HttpContext.Response.Cookies.Append("BookMe", "1");

            //if (isVoucherCookiesGroupConsented)
            //    HttpContext.Response.Cookies.Append("Vouchers", "1");

            HttpContext.Response.Cookies.Append("OptanonConsent", "isIABGlobal=false&datestamp=Tue Jan 19 2021 11:00:58 GMT+0100 (heure normale d’Europe centrale)&version=6.9.0&landingPath=NotLandingPage&AwaitingReconsent=false&groups=1:1,2:1,4:1,0_165859:1,0_165858:1,0_165861:1,0_165860:1,0_165863:1,0_165862:1,0_165865:1,0_165864:1,0_165867:1,0_165866:1,0_165869:1,0_165868:1,0_165870:1,0_165853:1,0_165855:1,0_165854:1,0_165857:1,0_165856:1");
            var settings = _cookiesManagementProvider.GetCurrentUserCookiesSettings();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
