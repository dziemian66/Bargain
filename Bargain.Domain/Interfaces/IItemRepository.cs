using Bargain.Domain.Model;

namespace Bargain.Domain.Interfaces
{
    public interface IItemRepository
    {
        public void DeleteItem(int itemId);
        public int AddItem(Item item);
        public Item GetItemById(int id);
        public IQueryable<Item> GetActiveItemsByTypeId(int typeId);
        public IQueryable<Item> GetActiveItemsByShopId(int shopeId);
        public IQueryable<Item> GetActiveItemsByCityId(int cityId);
        public IQueryable<Item> GetAllActiveItems();
 
    }
}