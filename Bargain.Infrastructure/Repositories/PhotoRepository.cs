using Bargain.Domain.Interfaces;
using Bargain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Infrastructure.Repositories
{
    public class PhotoRepository:IPhotoRepository
    {
        readonly Context _context;
        public PhotoRepository(Context context)
        {
            _context = context;
        }

        public int AddPhoto(Photo photo)
        {
            _context.Add(photo);
            _context.SaveChanges();
            return photo.Id;
        }
    }
}
