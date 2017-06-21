using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? SalonId { get; set; }
        public SalonDto Salon { get; set; }
    }
}
