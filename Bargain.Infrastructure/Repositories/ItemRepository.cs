using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Bargain.Infrastructure.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly Context _context;
        public ItemRepository(Context context)
        {
            _context = context;
        }
        public void DeleteItem(int itemId)
        {
            var item = _context.Items.FirstOrDefault(x=>x.Id== itemId);
            if(item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
        public int AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item.Id;
        }
        public Item GetItemById(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            return item;
        }
        public IQueryable<Item> GetItemsByTypeId(int typeId) 
        {
            var items = _context.Items.Where(i => i.TypeId== typeId);
            return items;
        }
        public IQueryable<Item> GetItemsByShopId(int shopeId)
        {
            var items = _context.Items.Where(i => i.ShopId == shopeId);
            return items;
        }
        public IQueryable<Item> GetItemsByCityId(int cityId)
        {
            var items = _context.Items.Where(i => i.CityId == cityId);
            return items;
        }
        public IQueryable<Item> GetAllItems()
        {
            var items = _context.Items;
            return items;
        }
        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }
        public IQueryable<Shop> GetAllShops()
        {
            var shops = _context.Shops;
            return shops;
        }
    }
}
