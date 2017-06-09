using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Dtos
{
    public class TagDto : BaseDto
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        
        public IEnumerable<PostTagDto> PostTags { get; set; }
    }
}
