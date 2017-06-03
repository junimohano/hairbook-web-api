using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.Swagger.Model;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostTag))]
    public class PostTag : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostTagId { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
        
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
