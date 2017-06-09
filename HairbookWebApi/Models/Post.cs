using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Models
{
    [Table(nameof(Post))]
    public class Post : Base
    {
        public Post()
        {
            PostHairMenus = new List<PostHairMenu>();
            PostHairTypes = new List<PostHairType>();
            PostEvaluations = new List<PostEvaluation>();
            PostTags = new List<PostTag>();
            PostUploads = new List<PostUpload>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime Date { get; set; }
        public string Memo { get; set; }

        public int? SalonId { get; set; }
        public Salon Salon { get; set; }
        
        public int? HairTypeId { get; set; }
        public HairType HairType { get; set; }
        public string HairMemo { get; set; }

        public AccessType AccessType { get; set; }

        public IEnumerable<PostHairMenu> PostHairMenus { get; set; }
        public IEnumerable<PostHairType> PostHairTypes { get; set; }
        public IEnumerable<PostEvaluation> PostEvaluations { get; set; }
        public IEnumerable<PostTag> PostTags { get; set; }
        public IEnumerable<PostUpload> PostUploads { get; set; }

        // todo: draw functions
    }
}
