using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HairbookWebApi.Models
{
    [Table(nameof(EvaluationType))]
    public class EvaluationType : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvaluationTypeId { get; set; }

        public string Type { get; set; }
    }
}
