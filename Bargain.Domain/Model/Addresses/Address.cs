using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model.Addresses
{
    public class Address
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int CountryId{ get; set; }
        public virtual Country Country { get; set; }
        public int UserRef { get; set; }
        public User User { get; set; }
    }
}
