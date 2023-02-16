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
        
        public int Likes { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public Item(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price; 
        }
    }
}
