using Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BlogHistory : IEntity
    {
        [Key]
        public int ID { get; set; }

        public BlogContent Content { get; set; }

        public SystemFields SystemFields { get; set; }

        [Required]
        public virtual Blog Blog { get; set; }
    }
}
