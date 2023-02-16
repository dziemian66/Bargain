namespace Bargain.Domain.Model
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}