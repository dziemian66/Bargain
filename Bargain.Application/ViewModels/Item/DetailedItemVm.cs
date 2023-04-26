using AutoMapper;
using Bargain.Application.Mapping;
using Bargain.Domain.Model.Addresses;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ViewModels.Item
{
    public class DetailedItemVm: IMapFrom<Bargain.Domain.Model.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bargain.Domain.Model.Photo> Photos { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal? EarlierPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal? DeliveryPrice { get; set; }
        public string TypeName { get; set; }
        public string AuthorName { get; set; }
        public string Url { get; set; }
        public string ShopName { get; set; }
        public bool LocalBargain { get; set; }
        public string? Province { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndOfPriceBargain { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BeginningOfPriceBargain { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bargain.Domain.Model.Item, DetailedItemVm>()
                .ForMember(s => s.TypeName, opt => opt.MapFrom(d => d.Type.Name))
                .ForMember(s => s.AuthorName, opt => opt.MapFrom(d => d.Author.Name))
                .ForMember(s => s.ShopName, opt => opt.MapFrom(d => d.Shop.Name))
                .ForMember(s => s.Province, opt => opt.MapFrom(d => d.Province.Name));
        }
    }
}
