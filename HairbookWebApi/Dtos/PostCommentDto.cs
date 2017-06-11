using System.Collections.Generic;

namespace HairbookWebApi.Dtos
{
    public class PostCommentDto : BaseDto
    {
        public int PostCommentId { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public string Comment { get; set; }

        public IEnumerable<TagDto> Tags { get; set; }
    }
}
