using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Interfaces
{
    public interface IPhotoRepository
    {
        public int AddPhoto(Photo photo);
        public void DeletePhotosByItemId(int itemId);
    }
}
