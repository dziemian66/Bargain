﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ViewModels.Interfaces
{
    public interface IHasFileCollectionVm
    {
        public IFormFileCollection Files { get; set; }
    }
}
