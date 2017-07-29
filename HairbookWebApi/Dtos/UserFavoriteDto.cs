using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class UserFavoriteDto : BaseDto
    {
        public int UserFavoriteId { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }
    }
}
