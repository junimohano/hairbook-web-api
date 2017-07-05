using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HairbookWebApi.Models.Enums;

namespace HairbookWebApi.Dtos
{
    public class CustomerDto : BaseDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Phone { get; set; }
    }
}
