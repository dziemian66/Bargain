using AutoMapper;
using Bargain.Application.Mapping;
using Bargain.Domain.Model.Addresses;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ViewModels.Item
{
    public class ItemToListVm: IMapFrom<Bargain.Domain.Model.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bargain.Domain.Model.Photo> Photos { get; set; }
        public decimal Price { get; set; }
        public decimal? EarlierPrice { get; set; }
        public int ShopId { get; set; }
        public bool LocalBargain { get; set; }
        public int? ProvinceId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bargain.Domain.Model.Item, ItemToListVm>();
        }
    }
}
