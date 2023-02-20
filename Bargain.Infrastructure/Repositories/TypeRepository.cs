using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Bargain.Domain.Model.Type;

namespace Bargain.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly Context _context;
        public TypeRepository(Context context)
        {
            _context = context;
        }
        public int AddType(Type type)
        {
            _context.Add(type);
            _context.SaveChanges();
            return type.Id;
        }

        public void DeleteType(int id)
        {
            var item = _context.Types.FirstOrDefault(t => t.Id == id);
            if(item != null)
            {
                _context.Types.Remove(item);
                _context.SaveChanges();
            }
        }

        public IQueryable<Type> GetAllTypes()
        {
            throw new NotImplementedException();
        }
    }
}
