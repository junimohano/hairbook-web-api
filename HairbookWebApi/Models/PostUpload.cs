using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostUpload))]
    public class PostUpload : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostUploadId { get; set; }

        public string Path { get; set; }
        public string Memo { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public UploadFileType UploadFileType { get; set; }
        public UploadCategoryType UploadCategoryType { get; set; }
    }
}
