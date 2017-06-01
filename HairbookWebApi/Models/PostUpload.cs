using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostUpload))]
    public class PostUpload : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostUploadId { get; set; }

        public string Path { get; set; }
        public string Description { get; set; }
        
        public UploadType UploadType { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
