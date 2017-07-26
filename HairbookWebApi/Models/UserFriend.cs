using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HairbookWebApi.Models
{
    [Table(nameof(UserFriend))]
    public class UserFriend : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserFriendId { get; set; }

        public int FriendId { get; set; }
        public User Friend { get; set; }
    }
}
