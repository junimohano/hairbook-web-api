using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(Post))]
    public class PostHairMenu : Base
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostHairMenuId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int HairMenuId { get; set; }
        public HairMenu HairMenu { get; set; }
        
        public int HairSubMenuId { get; set; }
        public HairSubMenu HairSubMenu { get; set; }

        public string Memo { get; set; }
        public byte[] Drawing { get; set; }

    }
}
