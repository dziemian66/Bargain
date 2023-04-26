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

namespace Bargain.Application.ViewModels.Item
{

    public class NewItemVm: IMapFrom<Bargain.Domain.Model.Item>
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        //[FromForm]
        //[NotMapped]
        public IFormFileCollection? Files { get; set; }
        public ICollection<Bargain.Domain.Model.Photo>? Photos { get; set; }
        public string? Description { get; set; }
        //[Required]
        public decimal Price { get; set; }
        public decimal? EarlierPrice { get; set; }
        public decimal? DeliveryPrice { get; set; }
        //[Required]
        public int? TypeId { get; set; }
        //[NotMapped]
        public List<TypeToSelectListVm>? TypeSelectList { get; set; }
        //Required, DataType(DataType.Url)]
        public string? Url { get; set; }
        //[Required]
        public int? ShopId { get; set; }
        //[NotMapped]
        public List<ShopToSelectListVm>? ShopSelectList { get; set; }
        //[Required]
        public bool LocalBargain { get; set; }
        public int? ProvinceId { get; set; }
        //[NotMapped]
        public List<ProvinceToSelectListVm>? ProvinceSelectList { get; set; }
        //[NotMapped]
        public List<CountryToSelectListVm>? CountrySelectList { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? EndOfPriceBargain { get; set; }
        //[DataType(DataType.Date)]
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
                .WithName("Tytuł");
            RuleFor(x => x.Description)
                .NotNull().MinimumLength(50)
                .MaximumLength(800)
                .WithName("Opis");
            RuleFor(x => x.ShopId)
                .NotNull()
                .NotEmpty()
                .WithName("Sklep");
            RuleFor(x => x.TypeId)
                .NotNull()
                .NotEmpty()
                .WithName("Kategoria");
            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .WithName("Cena promocji");
            RuleFor(x => x.EarlierPrice)
                .GreaterThanOrEqualTo(x => x.Price).WithMessage("Poprzednia cena nie może być niższa niż cena promocji")
                .WithName("Poprzednia cena");
            RuleFor(x => x.Url)
                .NotNull().WithMessage("Wprowadź link do okazji")
                .Must(BeAValidUrl).WithMessage("Niepoprawny format linku");
            RuleFor(x => x.Files)
                .NotNull().WithMessage("Dodaj grafikę przedstawiającą okazję")
                .Must(x => x != null && x.Count <= 6).WithMessage("Dodaj maksymalnie 6 obrazów") // Max 6 images
                .Must(x => x != null && x.Any(x => x.Length < 1048576)).WithMessage("Maksymalna wielkosć obrazka wynosi 1 MB") // Max 1 MB for one image
                .Must(BeAImageFiles).WithMessage("Próbujesz przesłać niepoprawny rodzaj pliku"); // Check ContentType
            // Stworzyć klasę do przechowywania  errorów i nazw np.
            // public static class ProductErrors {
            // public static string IdErrorMessage { get; set; } = "Id field cannot be null or empty."; }
        }

        private static bool BeAValidUrl(string url)
        {
            Uri outUri;
            return Uri.TryCreate(url, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
        private static bool BeAImageFiles(IFormFileCollection files)
        {
            bool areImages = false;
            if(files != null)
            {
                areImages = files.All(x => x.ContentType == "image/png" || x.ContentType == "image/jpeg" || x.ContentType == "image/jpg");
            }
            return areImages;
        }
    }
}
