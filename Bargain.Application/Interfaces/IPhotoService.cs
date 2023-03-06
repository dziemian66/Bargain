using Bargain.Application.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Interfaces
{
    public interface IPhotoService
    {
        public int AddPhoto(NewPhotoVm newPhotoVm);
    }
}
