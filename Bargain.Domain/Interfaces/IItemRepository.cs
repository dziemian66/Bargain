using Bargain.Domain.Model;

namespace Bargain.Domain.Interfaces
{
    public interface IItemRepository
    {
        public void DeleteItem(int itemId);

        public int AddItem(Item item);

        public Item GetItemById(int id);

        public IQueryable<Item> GetItemsByTypeId(int typeId);

        public IQueryable<Item> GetItemsByShopId(int shopeId);

        public IQueryable<Item> GetItemsByCityId(int cityId);

        public IQueryable<Item> GetAllItems();

        public IQueryable<Domain.Model.Type> GetAllTypes();

        public IQueryable<Shop> GetAllShops();
    }
}