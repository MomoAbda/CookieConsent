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
            var settings = _cookiesManagementProvider.GetCurrentUserCookiesSettings();

            var bookmeCookiesGroup = settings.GetGroupByName("BookMe");
            var isBookMeCookiesGroupConsented = settings.IsConsented(bookmeCookiesGroup);

            var voucherCookiesGroup = settings.GetGroupByName("Vouchers");
            var isVoucherCookiesGroupConsented = settings.IsConsented(voucherCookiesGroup);

            if (isBookMeCookiesGroupConsented)
                HttpContext.Response.Cookies.Append("BookMe", "1");

            if (isVoucherCookiesGroupConsented)
                HttpContext.Response.Cookies.Append("Vouchers", "1");

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
