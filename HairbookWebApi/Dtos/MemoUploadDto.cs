using HairbookWebApi.Models;

namespace HairbookWebApi.Dtos
{
    public class MemoUploadDto : BaseDto
    {
        public int MemoUploadId { get; set; }

        public string Path { get; set; }
        public string Description { get; set; }
        
        public UploadType UploadType { get; set; }

        public int MemoId { get; set; }
        public MemoDto Memo { get; set; }
    }
}
