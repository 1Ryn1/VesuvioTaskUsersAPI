using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class InputDetail
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string UserAge { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string UserAddress { get; set; }


    }
}
