using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(HairSubMenu))]
    public class HairSubMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HairSubMenuId { get; set; }
        public string Name { get; set; }

        public int HairMenuId { get; set; }
        public HairMenu HairMenu { get; set; }
    }
}
