using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Models
{
    [Table(nameof(UserFavorite))]
    public class UserFavorite : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserFavoriteId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
