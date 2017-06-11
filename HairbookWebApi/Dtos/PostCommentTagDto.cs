using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Dtos
{
    public class PostCommentTagDto : BaseDto
    {
        public int PostCommentTagId { get; set; }

        public int PostCommentId { get; set; }
        public PostCommentDto PostComment { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}
