using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model.Addresses
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
