using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis;

namespace HairbookWebApi.Dtos
{
    public class SalonDto : BaseDto
    {
        public int SalonId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
        public string Url { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
