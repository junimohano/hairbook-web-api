using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models;

namespace HairbookWebApi.Dtos
{
    [Table(nameof(TagDto))]
    public class TagDto : BaseDto
    {
        public TagDto()
        {
            PostTags = new List<PostTagDto>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string TagName { get; set; }
        
        public IEnumerable<PostTagDto> PostTags { get; set; }
    }
}
