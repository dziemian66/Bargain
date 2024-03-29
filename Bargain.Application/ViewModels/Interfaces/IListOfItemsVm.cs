﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bargain.Application.ViewModels.Item;

namespace Bargain.Application.ViewModels.Interfaces
{
    internal interface IListOfItemsVm
    {
        public List<ItemToListVm> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
