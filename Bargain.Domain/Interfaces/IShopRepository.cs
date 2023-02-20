using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Interfaces
{
    public interface IShopRepository
    {
        public int AddShop(Shop shop);
        public void DeleteShop(int id);
        public IQueryable<Shop> GetAllShops();
        public Shop GetShopById(int id);
    }
}
