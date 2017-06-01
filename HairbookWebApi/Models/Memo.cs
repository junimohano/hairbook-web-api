using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(Memo))]
    public class Memo : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemoId { get; set; }

        public string Title { get; set; }

        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        
        public AccessType AccessType { get; set; }
        
        public IEnumerable<MemoEvaluation> Evaluations { get; set; }
        public IEnumerable<MemoTag> Tags { get; set; }

        public IEnumerable<MemoUpload> Uploads { get; set; }
    }
}
