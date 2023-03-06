using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bargain.Application.Interfaces;
using Bargain.Application.Mapping;
using Bargain.Application.ViewModels.Item;
using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<int> AddItem(NewItemVm item, int authorId = 1)
        {
            var itm = _mapper.Map<Item>(item);
            itm.IsActive = true;
            itm.AuthorId = authorId; //Zostanie pobrane na podstawie zalogowanego użytkownika
            var id = await _itemRepository.AddItem(itm); 
            return id;
        }

        public ListItemToListVm GetAllItems(int totalPages, int currentPage, string searchString)
        {
            var items = _itemRepository.GetAllActiveItems().Where(i => i.Name.StartsWith(searchString))
                .ProjectTo<ItemToListVm>(_mapper.ConfigurationProvider).ToList();
            var itemsToShow = items.Skip(totalPages * (currentPage - 1)).Take(totalPages).ToList(); ;
            var itemList = new ListItemToListVm()
            {
                TotalPages = totalPages,
                CurrentPage = currentPage,
                SearchString = searchString,
                Items = itemsToShow,
                Count = itemsToShow.Count
            };
            return itemList;
        }

        public NewItemVm GetEditItem(int itemId)
        {
            var item = _itemRepository.GetActiveItemById(itemId);
            var itemVm = _mapper.Map<NewItemVm>(item);
            return itemVm;
        }

        public async Task UpdateItem(NewItemVm model)
        {
            var item = _mapper.Map<Item>(model);
            await _itemRepository.UpdateItem(item);
        }
    }
}
