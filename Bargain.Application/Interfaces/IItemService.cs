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
        ListItemToListVm GetAllItems(int totalPages, int currentPage, string searchString);
        NewItemVm GetEditItem(int itemId);
        Task UpdateItem(NewItemVm model);
        public List<TypeToSelectListVm> GetAllTypes();
    }
}
