using Bargain.Domain.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bargain.Web.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Earlier price")]
        public decimal EarlierPrice { get; set; }
        public ItemCategory Category { get; set; }
        public int Likes { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public Item(int id, string name, decimal price, ItemCategory category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category= category;
        }
    }
}
