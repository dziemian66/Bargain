using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IQueryable<Item> GetActiveItemsByTypeId(int typeId)
        {
            var items = _context.Items.Where(i => i.TypeId == typeId && i.IsActive == true);
            return items;
        }

        public IQueryable<Item> GetActiveItemsByShopId(int shopeId)
        {
            var items = _context.Items.Where(i => i.ShopId == shopeId && i.IsActive == true);
            return items;
        }

        public IQueryable<Item> GetActiveItemsByCityId(int cityId)
        {
            var items = _context.Items.Where(i => i.CityId == cityId && i.IsActive == true);
            return items;
        }

        public IQueryable<Item> GetAllActiveItems()
        {
            var items = _context.Items.Where(x => x.IsActive == true);
            return items;
        }
    }
}
