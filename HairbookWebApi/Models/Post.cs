using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(Post))]
    public class Post : Base
    {
        public Post()
        {
            Evaluations = new List<PostEvaluation>();
            Tags = new List<PostTag>();
            Uploads = new List<PostUpload>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int? SalonId { get; set; }
        public Salon Salon { get; set; }
        
        public AccessType AccessType { get; set; }

        public IEnumerable<PostEvaluation> Evaluations { get; set; }
        public IEnumerable<PostTag> Tags { get; set; }
        public IEnumerable<PostUpload> Uploads { get; set; }

        // todo: draw functions
    }
}
