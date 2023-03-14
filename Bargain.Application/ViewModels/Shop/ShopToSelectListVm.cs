using AutoMapper;
using Bargain.Application.Mapping;

namespace Bargain.Application.ViewModels.Shop
{
    public class ShopToSelectListVm: IMapFrom<Bargain.Domain.Model.Shop>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bargain.Domain.Model.Shop, ShopToSelectListVm>();
        }
    }
}
