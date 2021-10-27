﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoderQuandaryBlog.Models
{
    public class BlogUser : IdentityUser
    {
        //Data Annotations
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no greater than {1} characters long", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no greater than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public byte[] ImageData { get; set; }

        [Display(Name = "Content Type")]
        public string ContentType { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no greater than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Facebook Link")]
        public string FacebookUrl { get; set; }
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no greater than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Twitter Link")]
        public string TwitterUrl { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }

        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();


    }
}
