using Bargain.Domain.Interfaces;
using Bargain.Domain.Model.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        readonly private Context _context;
        public AddressRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Country> GetAllCountry()
        {
            var country = _context.Countries;
            return country;
        }

        public IQueryable<Province> GetAllProvinces()
        {
            var provinces = _context.Provinces;
            return provinces;
        }
    }
}
