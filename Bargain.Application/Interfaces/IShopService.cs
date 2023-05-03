using Bargain.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Interfaces
{
    public interface IShopService
    {
        public List<ShopToSelectListVm> GetAllShops();
        public string GetShopUrlById(int shopId);
    }
}
