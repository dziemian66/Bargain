using Bargain.Application;
using Bargain.Application.Interfaces;
using Bargain.Application.Services;
using Bargain.Application.ViewModels.Interfaces;
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
            var itemId = await _itemService.AddItem(item);
            await _photoService.UploadPhotoCollectionForItem(item, _environment.WebRootPath, itemId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var item = _itemService.GetEditItem(id);
            GetSelectListForCreateItem(item);
            return View(item);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditItem(NewItemVm item)
        {
            ValidationResult result = await _newItemValid.ValidateAsync(item);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                GetSelectListForCreateItem(item);
                return View(item);
            }
            var itemId = await _itemService.UpdateItem(item);
            _photoService.DeletePhotosByItemId(itemId); // Delete every photos before you upload new
            await _photoService.UploadPhotoCollectionForItem(item, _environment.WebRootPath, itemId);  
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Add list of shops, provinces and types to select when you create or edit item
        /// </summary>
        /// <param name="item"></param>
        private void GetSelectListForCreateItem(NewItemVm item)
        {
            item.CountrySelectList = _addressesService.GetAllCountry();
            item.ProvinceSelectList = _addressesService.GetAllProvinces();
            item.ShopSelectList = _shopService.GetAllShops();
            item.TypeSelectList = _itemService.GetAllTypes();
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
