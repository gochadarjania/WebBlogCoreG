using Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BlogComment : IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
        public SystemFields SystemFields { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Blog Blog { get; set; }
    }
}
