using System;

namespace HairbookWebApi.Dtos
{
    public abstract class BaseDto
    {
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public UserDto CreatedUser { get; set; }
        public UserDto UpdatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
