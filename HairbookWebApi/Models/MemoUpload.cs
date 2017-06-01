using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(MemoUpload))]
    public class MemoUpload : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemoUploadId { get; set; }

        public string Path { get; set; }
        public string Description { get; set; }
        
        public UploadType UploadType { get; set; }

        public int MemoId { get; set; }
        public Memo Memo { get; set; }
    }
}
