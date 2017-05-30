using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        
        public int UploadTypeId { get; set; }
        public UploadType Type { get; set; }

        public int MemoId { get; set; }
        public Memo Memo { get; set; }
    }
}
