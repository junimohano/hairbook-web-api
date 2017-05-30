using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace HairbookWebApi.Models
{
    [Table(nameof(Post))]
    public class Post : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int SalonId { get; set; }
        public Salon Salon { get; set; }

        public int AccessTypeId { get; set; }
        public AccessType AccessType { get; set; }

        public IEnumerable<PostEvaluation> Evaluations { get; set; }
        public IEnumerable<PostTag> Tags { get; set; }
        public IEnumerable<PostUpload> Uploads { get; set; }

        // todo: draw functions
    }
}
