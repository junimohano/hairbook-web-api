namespace HairbookWebApi.Dtos
{
    public class MemoTagDto : BaseDto
    {
        public int MemoTagId { get; set; }
        public string TagName { get; set; }
        
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int MemoId { get; set; }
        public MemoDto Memo { get; set; }
    }
}
