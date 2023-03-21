using Bargain.Application.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Bargain.Application.ViewModels.Address;
using Bargain.Application.ViewModels.Shop;

namespace Bargain.Application.ViewModels.Item
{
    public class NewItemVm: IMapFrom<Bargain.Domain.Model.Item>
    {
        public int Id { get; set; }
        [Required, StringLength(60, MinimumLength = 5)]
        public string Name { get; set; }
        [FromForm]
        [NotMapped]
        public IFormFileCollection Files { get; set; }
        public ICollection<Bargain.Domain.Model.Photo>? Photos { get; set; }
        [Required, StringLength(600,MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? EarlierPrice { get; set; }
        public decimal? DeliveryPrice { get; set; }
        [Required]
        public int TypeId { get; set; }
        [NotMapped]
        public List<TypeToSelectListVm>? TypeSelectList { get; set; }
        [Required, DataType(DataType.Url)]
        public string Url { get; set; }
        [Required]
        public int ShopId { get; set; }
        [NotMapped]
        public List<ShopToSelectListVm>? ShopSelectList { get; set; }
        [Required]
        public bool LocalBargain { get; set; }
        public int? ProvinceId { get; set; }
        [NotMapped]
        public List<ProvinceToSelectListVm>? ProvinceSelectList { get; set; }
        [NotMapped]
        public List<CountryToSelectListVm>? CountrySelectList { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndOfPriceBargain { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BeginningOfPriceBargain { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewItemVm, Bargain.Domain.Model.Item>().ReverseMap();
        }
    }
}
