namespace HairbookWebApi.Dtos
{
    public class PostTagDto : BaseDto
    {
        public int PostTagId { get; set; }

        public int TagId { get; set; }
        public TagDto Tag { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }
    }
}
