using HairbookWebApi.Models;

namespace HairbookWebApi.Dtos
{
    public class PostUploadDto : BaseDto
    {
        public int PostUploadId { get; set; }

        public string Path { get; set; }
        public string Description { get; set; }

        public UploadType UploadType { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }
    }
}
