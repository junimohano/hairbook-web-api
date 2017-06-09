using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairbookWebApi.Dtos
{
    public class UserFriendDto : BaseDto
    {
        public int UserFriendId { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int FriendId { get; set; }
        public UserDto Friend { get; set; }

        public bool IsFriend { get; set; }

    }
}
