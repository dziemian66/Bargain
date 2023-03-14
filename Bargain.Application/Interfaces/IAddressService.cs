using Bargain.Application.ViewModels.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Interfaces
{
    public interface IAddressService
    {
        public List<ProvinceToSelectListVm> GetAllProvinces();
        public List<CountryToSelectListVm> GetAllCountry();
    }
}
