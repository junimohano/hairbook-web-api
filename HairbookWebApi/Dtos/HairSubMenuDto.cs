using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models;

namespace HairbookWebApi.Dtos
{
    public class HairSubMenuDto
    {
        public int HairSubMenuId { get; set; }
        public string Name { get; set; }

        public int HairMenuId { get; set; }
        public HairMenu HairMenu { get; set; }
    }
}
