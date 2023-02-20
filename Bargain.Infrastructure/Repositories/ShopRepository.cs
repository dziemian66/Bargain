using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly Context _context;
        public ShopRepository(Context context)
        {
            _context= context;
        }
        public int AddShop(Shop shop)
        {
            _context.Add(shop);
            _context.SaveChanges();
            return shop.Id;
        }
        public void DeleteShop(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
        public Shop GetShopById(int id)
        {
            var shop = _context.Shops.FirstOrDefault(x => x.Id == id);
            return shop;
        }
        public IQueryable<Shop> GetAllShops()
        {
            var shops = _context.Shops;
            return shops;
        }
    }
}
