using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bargain.Application.Interfaces;
using Bargain.Application.ViewModels.Address;
using Bargain.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Services
{
    public class AddressService : IAddressService
    {
        readonly private IAddressRepository _addressRepository;
        readonly private IMapper _mapper;
        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public List<CountryToSelectListVm> GetAllCountry()
        {
            var counries = _addressRepository.GetAllCountry()
                .ProjectTo<CountryToSelectListVm>(_mapper.ConfigurationProvider).ToList();
            return counries;
        }

        public List<ProvinceToSelectListVm> GetAllProvinces()
        {
            var provinces = _addressRepository.GetAllProvinces()
                .ProjectTo<ProvinceToSelectListVm>(_mapper.ConfigurationProvider).ToList();    
            return provinces;
        }
    }
}
