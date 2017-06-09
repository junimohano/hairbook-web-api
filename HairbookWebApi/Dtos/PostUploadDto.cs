using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class PostUploadDto : BaseDto
    {
        public int PostUploadId { get; set; }

        public string Path { get; set; }
        public string Memo { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public UploadFileType UploadFileType { get; set; }
        public UploadCategoryType UploadCategoryType { get; set; }
    }
}
