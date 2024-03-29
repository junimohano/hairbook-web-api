﻿using System;

namespace HairbookWebApi.Models
{
    public abstract class Base
    {
        public int? CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
