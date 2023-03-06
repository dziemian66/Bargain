using Bargain.Domain.Model.Addresses;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bargain.Application.Mapping;
using AutoMapper;
using Type = Bargain.Domain.Model.Type;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bargain.Application.ViewModels.Item
{
    public class NewItemVm: IMapFrom<Bargain.Domain.Model.Item>
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }
        [FromForm]
        [NotMapped]
        public IFormFileCollection Files { get; set; }
        public ICollection<Bargain.Domain.Model.Photo>? Photos { get; set; }
        [Required, StringLength(500,MinimumLength = 20)]
        public string Description { get; set; }
        [Required,DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal EarlierPrice { get; set; }
        public int TypeId { get; set; }
        [Required, DataType(DataType.Url)]
        public string Url { get; set; }
        public int ShopId { get; set; }
        [Required]
        public bool LocalBargain { get; set; }
        public int? ProvinceId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewItemVm, Bargain.Domain.Model.Item>().ReverseMap();
        }
    }
}
