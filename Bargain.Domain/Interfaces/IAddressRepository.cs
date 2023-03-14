using Bargain.Domain.Model.Addresses;

namespace Bargain.Domain.Interfaces
{
    public interface IAddressRepository
    {
        IQueryable<Province> GetAllProvinces();
        IQueryable<Country> GetAllCountry();
    }
}
