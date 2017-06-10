using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.Swagger.Model;

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
