using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(User))]
    public class User : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserKey { get; set; }

        public int? SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}
