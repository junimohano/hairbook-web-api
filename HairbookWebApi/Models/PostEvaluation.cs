﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostEvaluation))]
    public class PostEvaluation : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostEvaluationId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public EvaluationType EvaluationType { get; set; }
    }
}
