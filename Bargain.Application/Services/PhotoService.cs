using AutoMapper;
using Bargain.Application.Interfaces;
using Bargain.Application.ViewModels.Interfaces;
using Bargain.Application.ViewModels.Item;
using Bargain.Application.ViewModels.Photo;
using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Services
{
    public class PhotoService: IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;
        public PhotoService(IPhotoRepository photoRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }
        
        public async Task UploadPhotoCollectionForItem(IHasFileCollectionVm fileCollectionVm, string webPath, int itemId)
        {
            string path = Path.Combine(webPath, "Uploads");
            CheckPathExists(path);
            if (fileCollectionVm.Files != null)
            {
                foreach (var file in fileCollectionVm.Files)
                {
                    var newPhoto = await CallAndAddPhotoFile(file, path);
                    newPhoto.ItemId = itemId;
                    AddPhoto(newPhoto);
                }
            }
        }
        public async Task UploadPhotoForUser(IHasFileVm fileVm, string webPath, int userId)
        {
            var file = fileVm.File;
            string path = Path.Combine(webPath, "Uploads");
            CheckPathExists(path);
            if (file != null)
            {
                var newPhoto = await CallAndAddPhotoFile(file, path);
                newPhoto.UserId = userId;
                AddPhoto(newPhoto);
            }
        }
        public async Task UploadPhotoForShop(IHasFileVm fileVm, string webPath, int shopId)
        {
            var file = fileVm.File;
            string path = Path.Combine(webPath, "Uploads");
            CheckPathExists(path);
            if (file != null)
            {
                var newPhoto = await CallAndAddPhotoFile(file, path);
                newPhoto.ShopId = shopId;
                AddPhoto(newPhoto);
            }
        }
        public void DeletePhotosByItemId(int itemId)
        {
            _photoRepository.DeletePhotosByItemId(itemId);
        }
        private void CheckPathExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private async Task<NewPhotoVm> CallAndAddPhotoFile(IFormFile file, string path)
        {
            string uniqueName = null;
            NewPhotoVm newPhoto = new NewPhotoVm();
            uniqueName = Guid.NewGuid().ToString() + "_" + file.FileName.ToString();
            newPhoto.FileName = uniqueName;
            newPhoto.FileType = file.ContentType;
            newPhoto.FileSize = file.Length;
            string filePath = Path.Combine(path, uniqueName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return newPhoto;
        }
        private int AddPhoto(NewPhotoVm photo)
        {
            var phot = _mapper.Map<Photo>(photo);
            var id = _photoRepository.AddPhoto(phot);
            return id;
        }
    }
}
