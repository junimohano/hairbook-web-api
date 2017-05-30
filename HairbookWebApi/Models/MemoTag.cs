using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HairbookWebApi.Models
{
    [Table(nameof(MemoTag))]
    public class MemoTag : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemoTagId { get; set; }
        public string TagName { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int MemoId { get; set; }
        public Memo Memo { get; set; }
    }
}
