using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostCommentTag))]
    public class PostCommentTag : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostCommentTagId { get; set; }

        public int PostCommentId { get; set; }
        public PostComment PostComment { get; set; }
        
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
