using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Models
{
    [Table(nameof(User))]
    public class User : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public GenderType Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Phone { get; set; }

        public int? SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}
