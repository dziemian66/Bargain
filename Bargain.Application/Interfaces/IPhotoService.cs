using Bargain.Application.ViewModels.Interfaces;
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
        public  Task UploadPhotoCollectionForItem(IHasFileCollectionVm fileCollectionVm, string webPath, int itemId);
        public  Task UploadPhotoForUser(IHasFileVm fileVm, string webPath, int userId);
        public  Task UploadPhotoForShop(IHasFileVm fileVm, string webPath, int shopId);
        public void DeletePhotosByItemId(int itemId);
    }
}
