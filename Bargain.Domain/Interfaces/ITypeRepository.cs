using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bargain.Domain.Model;
using Type = Bargain.Domain.Model.Type;

namespace Bargain.Domain.Interfaces
{
    public interface ITypeRepository
    {
        public int AddType(Type type);
        public void DeleteType(int id);
        public IQueryable<Type> GetAllTypes();
    }
}
