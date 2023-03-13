using Microsoft.AspNetCore.Mvc;
using RHWebApp.Models;
using System.Diagnostics;
using System.Globalization;

namespace RHWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //string[] x = new string[] { "100", "200", "300" };
            //var result = ConcatenaArreglo(x);
            //DateTime fecha = DateTime.ParseExact("01/02/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int[] numbers = { 2, 3, 4, 5 };
            var result = ElementosPares(numbers);
            ViewBag.Message = result;
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

        public static string ConcatenaArreglo(string[] px)
        {
            return String.Join(",", px);
        }

        public static string Mes(DateTime date)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES").DateTimeFormat;
            int month = date.Month;
            return dtinfo.GetMonthName(month);
        }

        public static int[] ElementosPares(int[] px)
        {
            var squaredNumbers = px.Where(x => x % 2 == 0).ToArray();
            Array.Sort(px);
            return squaredNumbers;
        }

        public static int[] OrdenaArreglo(int[] px)
        {
            Array.Sort(px);
            return px;
        }


    }
}