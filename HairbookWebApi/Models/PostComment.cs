﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.Swagger.Model;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostComment))]
    public class PostComment : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostCommentId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Comment { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}