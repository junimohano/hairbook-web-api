using HairbookWebApi.Models;

namespace HairbookWebApi.Dtos
{
    public class PostEvaluationDto : BaseDto
    {
        public int PostEvaluationId { get; set; }
        
        public EvaluationType EvaluationType { get; set; }
        
        public int PostId { get; set; }
        public PostDto Post { get; set; }
    }
}
