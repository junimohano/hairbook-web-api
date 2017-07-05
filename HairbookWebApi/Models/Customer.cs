using HairbookWebApi.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(Customer))]
    public class Customer : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Phone { get; set; }
    }
}
