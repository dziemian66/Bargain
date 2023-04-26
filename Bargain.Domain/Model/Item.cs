using Bargain.Domain.Model.Addresses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }     
        public virtual ICollection<Photo> Photos { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? EarlierPrice { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public Rating? Rating { get; set; }
        public string? Url { get; set; }
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
        public bool LocalBargain { get; set; }
        public int? ProvinceId { get; set; }
        public virtual Province? Province { get; set; }
        public DateTime? EndOfPriceBargain { get; set; }
        public DateTime? BeginningOfPriceBargain { get; set; }
        public bool IsActive { get; set; }
    }
}
