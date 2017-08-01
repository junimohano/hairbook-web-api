using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class UserDto : BaseDto
    {
        public int UserId { get; set; }

        public string UserKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public GenderType Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Provider { get; set; }

        public int? SalonId { get; set; }
        public SalonDto Salon { get; set; }

        public IEnumerable<PostFavoriteDto> PostFavorites { get; set; }
        public IEnumerable<UserFriendDto> UserFollowing { get; set; }
        public IEnumerable<UserFriendDto> Userfollowers { get; set; }

        public int TotalUserFollowing { get; set; }
        public int TotalUserFollowers { get; set; }
        public int TotalUserPosts{ get; set; }
        public bool IsFollowing { get; set; }
    }
}
