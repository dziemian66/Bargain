using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bargain.Application.Interfaces;
using Bargain.Application.ViewModels.Shop;
using Bargain.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Services
{
    public class ShopService: IShopService
    {
        readonly private IShopRepository _shopRepository;
        readonly private IMapper _mapper;
        public ShopService(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }
        public List<ShopToSelectListVm> GetAllShops()
        {
            var shops = _shopRepository.GetAllShops()
                .ProjectTo<ShopToSelectListVm>(_mapper.ConfigurationProvider).ToList();
            return shops;
        }
        public string GetShopUrlById(int shopId)
        {
            var shopUrl = _shopRepository.GetShopById(shopId).Url;
            return shopUrl;
        }
    }
}
