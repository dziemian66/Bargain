using AutoMapper;
using Bargain.Application.Mapping;
using Bargain.Domain.Model.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ViewModels.Address
{
    public class ProvinceToSelectListVm: IMapFrom<Province>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Province,ProvinceToSelectListVm>();
        }
    }
}
