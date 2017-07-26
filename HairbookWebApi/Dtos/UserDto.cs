﻿using System;
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

        public IEnumerable<UserFriendDto> Following { get; set; }
        public IEnumerable<UserFriendDto> Followers { get; set; }
    }
}
