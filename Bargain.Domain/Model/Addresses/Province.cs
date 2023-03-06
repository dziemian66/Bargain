using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model.Addresses
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Address> UserAddresses { get; set; }
    }
}
