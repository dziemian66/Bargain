using AutoMapper;
using Bargain.Application.Mapping;
using Bargain.Domain.Model.Addresses;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bargain.Application.ViewModels.Item
{
    public class ItemToListVm: IMapFrom<Bargain.Domain.Model.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public virtual Bargain.Domain.Model.Photo Photo { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal? EarlierPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal? DeliveryPrice { get; set; }
        public string Url { get; set; }
        public int? RatingValue { get; set; }
        public string Shop { get; set; }
        public bool LocalBargain { get; set; }
        public string? Province { get; set; }
        public DateTime? EndOfPriceBargain { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bargain.Domain.Model.Item, ItemToListVm>()
                .ForMember(s => s.ShortDescription, opt => opt.MapFrom(d => d.Description.Substring(0, 200) + (d.Description.Length > 200 ? "..." : "")))
                .ForMember(s => s.Photo, opt => opt.MapFrom(d => d.Photos.FirstOrDefault(p =>p.FileName!=null)))
                .ForMember(s => s.RatingValue, opt => opt.MapFrom(d => d.Rating.Value))
                .ForMember(s => s.Shop, opt => opt.MapFrom(d => d.Shop.Name))
                .ForMember(s => s.Province, opt => opt.MapFrom(d => d.Province.Name));
        }
    }
}
