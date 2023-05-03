using AutoMapper;
using Bargain.Application.Mapping;
using Bargain.Application.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ViewModels.Photo
{
    public class NewPhotoVm:IMapFrom<Bargain.Domain.Model.Photo>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public int? UploaderId { get; set; } //User Id who upload this photo
        public int? ItemId { get; set; }
        public int? UserId { get; set; }
        public int? ShopId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPhotoVm, Bargain.Domain.Model.Photo>();
        }
    }

}
