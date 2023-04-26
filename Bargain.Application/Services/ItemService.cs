﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bargain.Application.Interfaces;
using Bargain.Application.Mapping;
using Bargain.Application.ViewModels.Item;
using Bargain.Application.ViewModels.Item.Interfaces;
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
        private IListOfItemsVm AddPaginationToListOfItem(IListOfItemsVm itemListVm, List<ItemToListVm> items, int pageSize, int pageNo)
        {
            itemListVm.Items = items.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            itemListVm.PageSize = pageSize;
            itemListVm.CurrentPage = pageNo;
            itemListVm.Count = items.Count;
            return itemListVm;
        }
        public async Task<int> AddItem(NewItemVm item, int authorId = 1)
        {
            var itm = _mapper.Map<Item>(item);
            itm.IsActive = true;
            itm.AuthorId = authorId; //Zostanie pobrane na podstawie zalogowanego użytkownika
            var id = await _itemRepository.AddItem(itm); 
            return id;
        }

        public ListItemToListVm GetAllItems(int pageSize, int pageNo)
        {
            var items = _itemRepository.GetAllActiveItems().OrderByDescending(i => i.Id).ProjectTo<ItemToListVm>(_mapper.ConfigurationProvider).ToList();
            var itemListVm = new ListItemToListVm();
            AddPaginationToListOfItem(itemListVm, items, pageSize, pageNo);
            return itemListVm;
        }
        public ListItemToListForSingleTypeVm GetItemsByType(int typeid, int pageSize, int pageNo)
        {
            var items = _itemRepository.GetActiveItemsByTypeId(typeid).OrderByDescending(i => i.Id).ProjectTo<ItemToListVm>(_mapper.ConfigurationProvider).ToList();
            var itemListVm = new ListItemToListForSingleTypeVm();
            AddPaginationToListOfItem(itemListVm, items, pageSize, pageNo);
            var type = GetTypeDetails(typeid);
            itemListVm.TypeId = type.Id;
            itemListVm.TypeName = type.Name;
            itemListVm.TypeIconFile = type.IconFile;
            return itemListVm;
        }
        public DetailedItemVm GetDetailedItemById(int itemId)
        {
            var item = _itemRepository.GetActiveItemById(itemId);
            var itemVm = _mapper.Map<DetailedItemVm>(item);
            return itemVm;
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
        public List<TypeToSelectListVm> GetAllTypes()
        {
            var types = _itemRepository.GetAllTypes()
                .ProjectTo<TypeToSelectListVm>(_mapper.ConfigurationProvider).OrderBy(t => t.Name).ToList();
            return types;
        }
        public TypeDetailsVm GetTypeDetails(int typeId)
        {
            var type = _itemRepository.GetTypeDetails(typeId);
            var typeVm = _mapper.Map<TypeDetailsVm>(type);
            return typeVm;
        }
    }
}
