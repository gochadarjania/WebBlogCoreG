using Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class User : IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(40)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(100)]
        public string Mail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public UserStatus Status { get; set; } = UserStatus.Registered;

        public SystemFields SystemFields { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

        public virtual ICollection<BlogComment> Comments { get; set; }
    }

    public enum UserStatus : byte
    {
        Registered = 0,
        Verified = 1,
        Deactivated = 2
    }
}
