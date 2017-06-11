using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis;

namespace HairbookWebApi.Models
{
    [Table(nameof(Salon))]
    public class Salon : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalonId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Url { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
