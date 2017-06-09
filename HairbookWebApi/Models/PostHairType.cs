using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Models
{
    [Table(nameof(PostHairType))]
    public class PostHairType : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostHairTypeId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int HairTypeId { get; set; }
        public HairType HairType { get; set; }
    }
}
