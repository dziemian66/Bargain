using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Interfaces
{
    public interface IUserRepository
    {
        public void DeleteUser(int userId);
        public int AddUser(User user);
        public User GetUserById(int id);
    }
}
