namespace HairbookWebApi.Dtos
{
    public class PostTagDto : BaseDto
    {
        public int PostTagId { get; set; }
        public string TagName { get; set; }
        
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }
    }
}
