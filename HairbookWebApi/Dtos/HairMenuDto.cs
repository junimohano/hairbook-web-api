using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Dtos
{
    public class HairMenuDto
    {
        public int HairMenuId { get; set; }

        public string Name { get; set; }

        public IEnumerable<HairSubMenuDto> HairSubMenus { get; set; }

    }
}
