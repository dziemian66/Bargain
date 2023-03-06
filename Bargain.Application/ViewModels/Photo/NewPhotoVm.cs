using AutoMapper;
using Bargain.Application.Mapping;
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
        public int ItemId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPhotoVm, Bargain.Domain.Model.Photo>();
        }
    }

}
