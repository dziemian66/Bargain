using Bargain.Domain.Model.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal EarlierPrice { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public Rating Rating { get; set; }
        public string Url { get; set; }
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
        public bool LocalBargain { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public bool IsActive { get; set; }
    }
}
