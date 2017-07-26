using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class UserFriendDto : BaseDto
    {
        public int UserFriendId { get; set; }

        public int FriendId { get; set; }
        public UserDto Friend { get; set; }
    }
}
