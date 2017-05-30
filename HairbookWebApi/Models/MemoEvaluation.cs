using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HairbookWebApi.Models
{
    [Table(nameof(MemoEvaluation))]
    public class MemoEvaluation : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemoEvaluationId { get; set; }

        public int EvaluationTypeId { get; set; }
        public EvaluationType EvaluationType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MemoId { get; set; }
        public Memo Memo { get; set; }
    }
}
