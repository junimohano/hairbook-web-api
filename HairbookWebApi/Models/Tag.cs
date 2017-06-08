using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(Tag))]
    public class Tag : Base
    {
        public Tag()
        {
            PostTags = new List<PostTag>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string TagName { get; set; }
        
        public IEnumerable<PostTag> PostTags { get; set; }
    }
}
