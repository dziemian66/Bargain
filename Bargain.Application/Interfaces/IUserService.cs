using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Application.Interfaces
{
    public interface IUserService
    {
        int AddNewUser(User user);
    }
}
