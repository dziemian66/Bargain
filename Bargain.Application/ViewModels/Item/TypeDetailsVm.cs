using AutoMapper;
using Bargain.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.ViewModels.Item
{
    public class TypeDetailsVm: IMapFrom<Bargain.Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bargain.Domain.Model.Type, TypeDetailsVm>();
        }
    }
}
