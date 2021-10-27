using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderQuandaryBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string BlogUserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no greater than {1} characters long.")]
        public string Text { get; set; }
        public virtual Post Post { get; set; }
        public virtual BlogUser BlogUsers { get; set; }
    }
}
