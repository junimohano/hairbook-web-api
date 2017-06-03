using HairbookWebApi.Models;
using System;
using System.Collections.Generic;

namespace HairbookWebApi.Dtos
{
    public class PostDto : BaseDto
    {
        public PostDto()
        {
            Evaluations = new List<PostEvaluationDto>();
            Tags = new List<PostTagDto>();
            Uploads = new List<PostUploadDto>();
        }
        public int PostId { get; set; }

        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int SalonId { get; set; }
        public SalonDto Salon { get; set; }
        
        public AccessType AccessType { get; set; }

        public IEnumerable<PostEvaluationDto> Evaluations { get; set; }
        public IEnumerable<PostTagDto> Tags { get; set; }
        public IEnumerable<PostUploadDto> Uploads { get; set; }

        // todo: draw functions
    }
}
