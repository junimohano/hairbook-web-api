﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class PostEvaluationDto : BaseDto
    {
        public int PostEvaluationId { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public EvaluationType EvaluationType { get; set; }
    }
}
