using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.Swagger.Model;

namespace HairbookWebApi.Models
{
    [Table(nameof(MemoTag))]
    public class MemoTag : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemoTagId { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int MemoId { get; set; }
        public Memo Memo { get; set; }
    }
}
