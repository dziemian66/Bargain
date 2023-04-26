using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using Bargain.Domain.Model.Addresses;
using Microsoft.EntityFrameworkCore;
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
        public async Task<int> AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public Item GetActiveItemById(int id)
        {
            var item = _context.Items.Include(i => i.Photos).Include(i=>i.Author).Include(i=>i.Province).Include(i=>i.Type).Include(i=>i.Shop)
                .FirstOrDefault(i => i.Id == id && i.IsActive == true);
            return item;
        }
        public async Task UpdateItem(Item item)
        {
            _context.Attach(item);
            _context.Entry(item).Property("Name").IsModified = true;
            _context.Entry(item).Property("Photos").IsModified = true;
            _context.Entry(item).Property("Description").IsModified = true;
            _context.Entry(item).Property("Price").IsModified= true;
            _context.Entry(item).Property("EarlierPrice").IsModified= true;
            _context.Entry(item).Property("TypeId").IsModified= true;
            _context.Entry(item).Property("ShopId").IsModified= true;
            _context.Entry(item).Property("LocalBargain").IsModified= true;
            _context.Entry(item).Property("ProvinceId").IsModified= true;
            await _context.SaveChangesAsync();
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

        public IQueryable<Item> GetActiveItemsByProvinceId(int provinceId)
        {
            var items = _context.Items.Where(i => i.ProvinceId == provinceId && i.IsActive == true);
            return items;
        }

        public IQueryable<Item> GetAllActiveItems()
        {
            var items = _context.Items.Where(x => x.IsActive == true);
            return items;
        }
        public IQueryable<Bargain.Domain.Model.Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }
        public Bargain.Domain.Model.Type GetTypeDetails(int typeid)
        {
            var type = _context.Types.FirstOrDefault(t => t.Id == typeid);
            return type;
        }
    }
}
