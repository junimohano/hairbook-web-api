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
            PostComments = new List<PostComment>();
            PostUploads = new List<PostUpload>();
            PostFavorites = new List<PostFavorite>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        public string Title { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public bool IsMemo { get; set; }

        public int? SalonId { get; set; }
        public Salon Salon { get; set; }
        
        public string HairTypeMemo { get; set; }
        public bool IsHairTypeMemo { get; set; }

        public AccessType AccessType { get; set; }

        public IEnumerable<PostHairMenu> PostHairMenus { get; set; }
        public IEnumerable<PostHairType> PostHairTypes { get; set; }
        public IEnumerable<PostEvaluation> PostEvaluations { get; set; }
        public IEnumerable<PostComment> PostComments { get; set; }
        public IEnumerable<PostUpload> PostUploads { get; set; }
        public IEnumerable<PostFavorite> PostFavorites { get; set; }

        // todo: draw functions
    }
}
