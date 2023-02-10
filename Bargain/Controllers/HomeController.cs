using Bargain.Domain.Utils;
using Bargain.Models;
using Bargain.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace Bargain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Item> Items;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //Example data
            Items = new List<Item>();
            Items.Add(new Item(1, "Zegarek Casio EQB-1200D-1AER", 731.54m, ItemCategory.Clothes)
            { EarlierPrice = 1089.67m, Likes = 210, Link = "https://www.pepper.pl/promocje/casio-eqb-1200d-1aer-643563", Description = "Solar, szafir, bluetooth, alarm"});
            Items.Add(new Item(2, "Knipex 13 86 200 szczypce wielofunkcyjne izolowane", 162.90m, ItemCategory.Automotive)
            { EarlierPrice = 225.19m, Likes = 329, Link = "https://www.amazon.pl/dp/B007AKG4VC?tag=ugcplpepper21-21&ascsubtag=410435241", Description = "Bardzo dobrej jakości izolowane szczypce 6w1.\r\n\r\nW poprzedniej wstawce cieszyły się dużą popularnością, a teraz cena jest jeszcze niższa." });
            Items.Add(new Item(3, "Kamera Wi-Fi Appartme", 79m, ItemCategory.Automotive)
            { EarlierPrice = 149m, Likes = 2, Link = "https://www.x-kom.pl/p/739813-inteligentna-kamera-appartme-kamera-wifi.html", Description = "Bardzo dobrej jakości izolowane szczypce 6w1.\r\n\r\nW poprzedniej wstawce cieszyły się dużą popularnością, a teraz cena jest jeszcze niższa."});
            Items.Add(new Item(4, "Piwo Żywiec lekkie 2 rodzaje butelka 0,4L 1+1 gratis", 2.10m, ItemCategory.Grocery)
            { EarlierPrice = 4.19m, Likes = 100, Link = "https://intermarche.pl/", Description = "Do wyboru 2 rodzaje:\r\n- lekki jasny oranż\r\n- lekki jasny limonż" });
            Items.Add(new Item(5, "Smartfon SAMSUNG Galaxy S20FE 1799,10ZŁ WŁOCŁAWEK", 1799.10m, ItemCategory.Electronics)
            { Likes = -23, Description = "S20FE w fajnej cenie tutaj akurat NEONET Włocławek nie wiem jak inne miasta. S20FE 6/128GB 6,5 cala, super amoled 2X."});
            Items.Add(new Item(6, "Botki szurowane \"Pascal\" dr. Martens rozmiary od 43 do 46", 256.47m, ItemCategory.Clothes)
            { EarlierPrice = 854.90m, Likes =  199, Link = "https://www.aboutyou.pl/p/dr-martens/botki-sznurowane-pascal-8981307", Description = "Dr. Martens Botki sznurowane 'Pascal' w kolorze JasnoszaryDesign & dodatki\r\nJednolite kolory\r\nSkóra\r\nZaokrąglony czubek\r\nProfil podeszwy\r\nWzmocniona pięta\r\nSznurowanie na 8 dziurek\r\nPasek przy kostce\r\nGładki w dotyku\r\nElastyczna podeszwa\r\nMetalowe oczka\r\nSkóra zamszowa\r\nZamknięcie sznurowe\r\nWysokość obcasa: Płaski obcas (0-3 cm)"});
            Items.Add(new Item(7, "LEGO Creator 3 w 1 31126 Odrzutowiec naddźwiękowy", 63.99m, ItemCategory.ToysAndGames)
            { Likes = 427, Link = "https://www.amazon.pl/dp/B09BNTPGVD?tag=ugcplpepper21-21&ascsubtag=410446285", Description = "Lego Creator 3w1sonic Jet Building Kit zawiera 3 modele w 1: odrzutowiec, zabawkowy helikopter i zabawkową łódkę. 215 el."});
        }

        public IActionResult ViewListOfNewItems() 
        {
            return View(Items);
        }

        [Route("TopRated")]
        public IActionResult ViewListOfTopRatedItems()
        {
            var items = Items.Where(i => i.Likes >= 200)
                .OrderByDescending(i=>i.Likes);
            return View(items);
        }

        [Route("Home/Details/{id:int?}")]
        public IActionResult ViewItemDetails(int id, int cos)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            return View(item);
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