using Bargain.Application.ViewModels.Item;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Interfaces
{
    public interface IItemService
    {
        Task<int> AddItem(NewItemVm item, int authorId = 1);
        ListItemToListVm GetAllItems(int pageSize, int pageNo);
        ListItemToListForSingleTypeVm GetItemsByType(int typeid, int pageSize, int pageNo);
        DetailedItemVm GetDetailedItemById(int id);
        NewItemVm GetEditItem(int itemId);
        Task UpdateItem(NewItemVm model);
        List<TypeToSelectListVm> GetAllTypes();
    }
}
