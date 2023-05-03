using Bargain.Domain.Model.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Photo? Photo { get; set; }
        public string? Description { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Photo> UploadedPhotos { get; set; }
        public virtual ICollection<Item> AddedItems { get; set; }
        public ICollection<UserRatingLike> UserRatingLikes { get; set; }
        public ICollection<UserRatingDislike> UserRatingDislikes { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
