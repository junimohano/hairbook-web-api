using System;

namespace HairbookWebApi.Dtos
{
    public class TokenDto
    {
        public DateTime RequestedAt { get; set; }
        public DateTime Expires { get; set; }
        public string AccessToken { get; set; }
        public UserDto User { get; set; }
    }
}
