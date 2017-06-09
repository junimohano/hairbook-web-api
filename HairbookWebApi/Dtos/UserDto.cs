using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
