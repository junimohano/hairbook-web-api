using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HairbookWebApi.Models
{
    [Table(nameof(AccessType))]
    public class AccessType : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessTypeId { get; set; }

        public string Name { get; set; }
    }
}
