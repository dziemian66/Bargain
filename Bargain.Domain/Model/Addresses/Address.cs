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
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }
        public int UserRef { get; set; }
        public User User { get; set; }
    }
}
