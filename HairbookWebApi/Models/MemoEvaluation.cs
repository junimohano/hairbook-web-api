using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(MemoEvaluation))]
    public class MemoEvaluation : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemoEvaluationId { get; set; }
        
        public EvaluationType EvaluationType { get; set; }

        public int MemoId { get; set; }
        public Memo Memo { get; set; }
    }
}
