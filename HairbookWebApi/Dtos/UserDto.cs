using System.Collections.Generic;

namespace HairbookWebApi.Dtos
{
    public class UserDto : BaseDto
    {
        public int UserId { get; set; }

        public string UserKey { get; set; }

        public int? SalonId { get; set; }
        public SalonDto Salon { get; set; }

        public IEnumerable<PostEvaluationDto> PostEvaluations { get; set; }
        public IEnumerable<MemoEvaluationDto> MemoEvaluations { get; set; }
        public IEnumerable<PostTagDto> PostTags { get; set; }
        public IEnumerable<MemoTagDto> MemoTags { get; set; }
    }
}
