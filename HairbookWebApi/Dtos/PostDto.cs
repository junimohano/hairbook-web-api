using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class PostDto : BaseDto
    {
        public int PostId { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public bool IsMemo { get; set; }

        public int? SalonId { get; set; }
        public SalonDto Salon { get; set; }
        
        public string HairTypeMemo { get; set; }
        public bool IsHairTypeMemo { get; set; }

        public AccessType AccessType { get; set; }

        public IEnumerable<PostHairMenuDto> PostHairMenus { get; set; }
        public IEnumerable<PostHairTypeDto> PostHairTypes { get; set; }
        public IEnumerable<PostEvaluationDto> PostEvaluations { get; set; }
        public IEnumerable<PostCommentDto> PostComments { get; set; }
        public IEnumerable<PostUploadDto> PostUploads { get; set; }
        public IEnumerable<PostFavoriteDto> PostFavorites { get; set; }

        public int TotalPostComments { get; set; }
        public int TotalPostEvaluations { get; set; }

        public bool IsEvaluation { get; set; }
        public bool IsFavorite { get; set; }
        // todo: draw functions
    }
}
