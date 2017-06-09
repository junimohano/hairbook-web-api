using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(HairMenu))]
    public class HairMenu
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HairMenuId { get; set; }

        public string Name { get; set; }

        public IEnumerable<HairSubMenu> HairSubMenus { get; set; }

    }
}
