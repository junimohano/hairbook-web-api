using HairbookWebApi.Models;

namespace HairbookWebApi.Dtos
{
    public class MemoEvaluationDto : BaseDto
    {
        public int MemoEvaluationId { get; set; }
        
        public EvaluationType EvaluationType { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int MemoId { get; set; }
        public MemoDto Memo { get; set; }
    }
}
