using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool? HeadingStatus{ get; set; }
        public string HeadingImage { get; set; }
        public int? CategoryID { get; set; } // category many to one
        public virtual Category Category { get; set; }

       public int? WriterID { get; set; } // writer many to one
       public virtual Writer Writer { get; set; }

       public ICollection<Content> Contents { get; set; } // content one to many
    }
}
