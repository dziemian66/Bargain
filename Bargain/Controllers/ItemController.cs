using Bargain.Application;
using Bargain.Application.Interfaces;
using Bargain.Application.Services;
using Bargain.Application.ViewModels.Item;
using Bargain.Application.ViewModels.Photo;
using Bargain.Domain.Model;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;

namespace Bargain.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IValidator<NewItemVm> _newItemValid;
        private readonly IPhotoService _photoService;
        private readonly IAddressService _addressesService;
        private readonly IShopService _shopService;
        private readonly IWebHostEnvironment _environment;
        public ItemController(IItemService itemService, IValidator<NewItemVm> newItemValid, IPhotoService photoService, IAddressService addressesService, IShopService shopService, IWebHostEnvironment environment)
        {
            _itemService = itemService;
            _newItemValid = newItemValid;
            _photoService = photoService;
            _addressesService = addressesService;
            _shopService = shopService;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult DetailedItem(int id)
        {
            var model = _itemService.GetDetailedItemById(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddItem()
        {
            var item = new NewItemVm();
            GetSelectListForCreateItem(item);
            return View(item);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddItem(NewItemVm item)
        {
            ValidationResult result = await _newItemValid.ValidateAsync(item);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                GetSelectListForCreateItem(item);
            //Re-render the view when validation failed.
                return View("AddItem", item);
            }
            var id = await _itemService.AddItem(item);
            ProcessUploadedFile(item, id);
            //return RedirectToAction("Home/Index");
            return RedirectToAction("Index", "Home");
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

        private void GetSelectListForCreateItem(NewItemVm item)
        {
            item.CountrySelectList = _addressesService.GetAllCountry();
            item.ProvinceSelectList = _addressesService.GetAllProvinces();
            item.ShopSelectList = _shopService.GetAllShops();
            item.TypeSelectList = _itemService.GetAllTypes();
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
    /// <summary>
    /// Add model errors for validating properties
    /// </summary>
    public static class Extensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
