using Bargain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace Bargain.Controllers
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
            return View();
        }
        //public IActionResult ViewListOfNewItems()
        //{
        //    return View(Items);
        //}

        //[Route("TopRated")]
        //public IActionResult ViewListOfTopRatedItems()
        //{
        //    var items = Items.Where(i => i.Likes >= 200)
        //        .OrderByDescending(i => i.Likes);
        //    return View(items);
        //}

        //[Route("Home/Details/{id:int?}")]
        //public IActionResult ViewItemDetails(int id)
        //{
        //    var item = Items.FirstOrDefault(i => i.Id == id);
        //    return View(item);
        //}

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