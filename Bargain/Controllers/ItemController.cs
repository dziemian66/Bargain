using Bargain.Application;
using Bargain.Application.Interfaces;
using Bargain.Application.Services;
using Bargain.Application.ViewModels.Item;
using Bargain.Application.ViewModels.Photo;
using Bargain.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bargain.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _environment;
        public ItemController(IItemService itemService, IPhotoService photoService, IWebHostEnvironment environment)
        {
            _itemService = itemService;
            _photoService = photoService;
            _environment = environment;
        }
        
        public IActionResult Index()
        {
            var model = _itemService.GetAllItems(4, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int totalPages, int currentPage, string searchString)
        {
            if(currentPage < 1) currentPage= 1;
            if(searchString is null) searchString = String.Empty;
            var model = _itemService.GetAllItems(totalPages, currentPage, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            return View(new NewItemVm());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddItem(NewItemVm item)
        {
            if(ModelState.IsValid)
            {
                var id = await _itemService.AddItem(item);
                ProcessUploadedFile(item, id);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var item = _itemService.GetEditItem(id);
            return View(item);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditItem(NewItemVm item)
        {
            if(ModelState.IsValid)
            {
                await _itemService.UpdateItem(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        private void ProcessUploadedFile(NewItemVm model, int id)
        {
            string uniqueName = null;
            string path = Path.Combine(_environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    NewPhotoVm newPhoto = new NewPhotoVm();
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                    uniqueName = Guid.NewGuid().ToString()+ "_" +file.FileName.ToString();
                    newPhoto.FileName = uniqueName;
                    newPhoto.ItemId = id;
                    _photoService.AddPhoto(newPhoto);
                    string filePath = Path.Combine(uploadsFolder, uniqueName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }   
            }
        }

    }
}
