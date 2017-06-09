using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class PostHairTypeDto : BaseDto
    {
        public int PostHairTypeId { get; set; }

        public int PostId { get; set; }
        public PostDto Post { get; set; }

        public int HairTypeId { get; set; }
        public HairTypeDto HairType { get; set; }
    }
}
