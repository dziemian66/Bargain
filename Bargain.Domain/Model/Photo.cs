using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargain.Domain.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public int? ItemId { get; set; }
        public virtual Item? Item { get; set; }
        public int? ShopRef { get; set; }
        public Shop? Shop { get; set; }
        public int? UserRef { get; set; }
        public User? User { get; set; }
        public int? UploaderId { get; set; } //User who upload this photo
        public User? Uploader { get; set; }
    }
}
