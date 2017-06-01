using System.Collections.Generic;

namespace HairbookWebApi.Dtos
{
    public class UserDto : BaseDto
    {
        public int UserId { get; set; }

        public string UserKey { get; set; }

        public int? SalonId { get; set; }
        public SalonDto Salon { get; set; }
    }
}
