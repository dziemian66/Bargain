using Bargain.Application.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Bargain.Application.ViewModels.Address;
using Bargain.Application.ViewModels.Shop;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Bargain.Application.ViewModels.Interfaces;
using Bargain.Application.ValidationMessages.PolishLanguage;

namespace Bargain.Application.ViewModels.Item
{

    public class NewItemVm: IMapFrom<Bargain.Domain.Model.Item>, IHasFileCollectionVm
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public IFormFileCollection? Files { get; set; }
        public ICollection<Bargain.Domain.Model.Photo>? Photos { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? EarlierPrice { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public int? TypeId { get; set; }
        public List<TypeToSelectListVm>? TypeSelectList { get; set; }
        public string? Url { get; set; }
        public int? ShopId { get; set; }
        public List<ShopToSelectListVm>? ShopSelectList { get; set; }
        public bool LocalBargain { get; set; }
        public int? ProvinceId { get; set; }
        public List<ProvinceToSelectListVm>? ProvinceSelectList { get; set; }
        public List<CountryToSelectListVm>? CountrySelectList { get; set; }
        public DateTime? EndOfPriceBargain { get; set; }
        public DateTime? BeginningOfPriceBargain { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewItemVm, Bargain.Domain.Model.Item>().ReverseMap();
        }
    }
    public class NewItemValidation : AbstractValidator<NewItemVm>
    {
        public NewItemValidation() {
            RuleFor(x => x.Id)
                .NotNull();
            RuleFor(x => x.Name)
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(80)
                .WithName(PropertiesNamesForItem.Name);
            RuleFor(x => x.Description)
                .NotNull().MinimumLength(50)
                .MaximumLength(800)
                .WithName(PropertiesNamesForItem.Description);
            RuleFor(x => x.ShopId)
                .NotNull()
                .NotEmpty()
                .WithName(PropertiesNamesForItem.Shop);
            RuleFor(x => x.TypeId)
                .NotNull()
                .NotEmpty()
                .WithName(PropertiesNamesForItem.Type);
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .WithName(PropertiesNamesForItem.Price);
            RuleFor(x => x.EarlierPrice)
                .GreaterThanOrEqualTo(x => x.Price).WithMessage(ErrorMessagesForItem.EarlierPriceBeNotGreaterThanCurrentPrice)
                .WithName(PropertiesNamesForItem.EarlierPrice);
            RuleFor(x => x.Url)
                .Must(BeAValidUrl).WithMessage(ErrorMessagesForItem.IncorrectUrlForm);
            RuleFor(x => x.Files)
                .NotNull().WithMessage(ErrorMessagesForItem.FileIsNull)
                .Must(x => x != null && x.Count <= 6).WithMessage(ErrorMessagesForItem.IncorrectCountOfFiles) // Max 6 images
                .Must(x => x != null && x.Any(x => x.Length < 1048576)).WithMessage(ErrorMessagesForItem.IncorrectFileSize) // Max 1 MB for one image
                .Must(BeAImageFiles).WithMessage(ErrorMessagesForItem.IncorrectFileContentType); // Check ContentType
        }

        private static bool BeAValidUrl(string url)
        {
            if (url == null)
            {
                return true;
            }
            Uri outUri;
            return Uri.TryCreate(url, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
        private static bool BeAImageFiles(IFormFileCollection files)
        {
            bool areImages = false;
            if(files != null)
            {
                areImages = files.All(x => x.ContentType == "image/png" || x.ContentType == "image/jpeg" || x.ContentType == "image/jpg" || x.ContentType == "image/webp");
            }
            return areImages;
        }
    }
}
