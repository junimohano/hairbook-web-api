using HairbookWebApi.Models;
using System.Collections.Generic;

namespace HairbookWebApi.Dtos
{
    public class MemoDto : BaseDto
    {
        public int MemoId { get; set; }

        public string Title { get; set; }

        public int SalonId { get; set; }
        public SalonDto Salon { get; set; }
        
        public AccessType AccessType { get; set; }
        
        public IEnumerable<MemoEvaluationDto> Evaluations { get; set; }
        public IEnumerable<MemoTagDto> Tags { get; set; }

        public IEnumerable<MemoUploadDto> Uploads { get; set; }
    }
}
