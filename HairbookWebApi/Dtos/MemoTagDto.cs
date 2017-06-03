namespace HairbookWebApi.Dtos
{
    public class MemoTagDto : BaseDto
    {
        public int MemoTagId { get; set; }

        public int TagId { get; set; }
        public TagDto Tag { get; set; }

        public int MemoId { get; set; }
        public MemoDto Memo { get; set; }
    }
}
