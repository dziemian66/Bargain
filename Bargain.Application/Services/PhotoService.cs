using AutoMapper;
using Bargain.Application.Interfaces;
using Bargain.Application.ViewModels.Photo;
using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
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
        public int AddPhoto(NewPhotoVm photo)
        {
            var phot = _mapper.Map<Photo>(photo);
            var id = _photoRepository.AddPhoto(phot);
            return id;
        }
    }
}
