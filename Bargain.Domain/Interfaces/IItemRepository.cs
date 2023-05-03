using Bargain.Domain.Model;

namespace Bargain.Domain.Interfaces
{
    public interface IItemRepository
    {
        public void DeleteItem(int itemId);
        public Task<int> AddItem(Item item);
        public int AddRatingToItemByItemId(int itemId);
        public Item GetActiveItemById(int id);
        public IQueryable<Item> GetActiveItemsByTypeId(int typeId);
        public IQueryable<Item> GetActiveItemsByShopId(int shopeId);
        public IQueryable<Item> GetActiveItemsByProvinceId(int provinceId);
        public IQueryable<Item> GetAllActiveItems();
        public Task<int> UpdateItem(Item item);
        public IQueryable<Bargain.Domain.Model.Type> GetAllTypes();
        public Bargain.Domain.Model.Type GetTypeDetails(int typeid);
    }
}