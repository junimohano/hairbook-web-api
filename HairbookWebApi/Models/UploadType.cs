using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HairbookWebApi.Models
{
    [Table(nameof(UploadType))]
    public class UploadType : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UploadTypeId { get; set; }

        public string Name { get; set; }
    }
}
