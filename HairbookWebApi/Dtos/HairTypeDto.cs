using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Dtos
{
    public class HairTypeDto
    {
        public int HairTypeId { get; set; }
        public string Name { get; set; }
    }
}
