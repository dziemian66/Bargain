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
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
