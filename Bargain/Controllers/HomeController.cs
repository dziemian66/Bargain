using Bargain.Application.Interfaces;
using Bargain.Application.ViewModels.Item;
using Bargain.Application.ViewModels.Photo;
using Bargain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace Bargain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;
        private readonly IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, IItemService itemService, IWebHostEnvironment environment)
        {
            _logger = logger;
            _itemService = itemService;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var model = _itemService.GetAllItems(8, 1);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int pageNo, string searchString)
        {
            if (pageNo < 1) pageNo = 1;
            if (searchString is null) searchString = String.Empty;
            var models = _itemService.GetAllItems(pageSize, pageNo);
            return View(models);
        }
        public IActionResult ListOfItemForSingleType(int typeid)
        {
            var model = _itemService.GetItemsByType(typeid, 10, 1);
            return View(model);
        }
        [HttpPost]
        public IActionResult ListOfItemForSingleType(int typeid, int pageSize, int pageNo)
        {
            if (pageNo < 1) pageNo = 1;
            var models = _itemService.GetItemsByType(typeid, pageSize, pageNo);
            return View(models);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}