using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.Swagger.Model;

namespace HairbookWebApi.Dtos
{
    public class PostTagDto
    {
        public int PostTagId { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public int TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}
