using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Dtos
{
    public class PostHairMenuDto : BaseDto
    {
        public int PostHairMenuId { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public int HairMenuId { get; set; }
        public HairMenuDto HairMenu { get; set; }
        
        public int HairSubMenuId { get; set; }
        public HairSubMenuDto HairSubMenu { get; set; }

        public string Memo { get; set; }
        public byte[] Drawing { get; set; }

    }
}
