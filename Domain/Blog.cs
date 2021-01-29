using Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Blog : IEntity
    {
        [Key]
        public int ID { get; set; }
        public BlogContent Published { get; set; }
        public BlogContent Draft { get; set; }
        public DateTime? LastPublishDate { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public SystemFields SystemFields { get; set; }
        // [Required]
        public virtual User User { get; set; }
        public virtual ICollection<BlogHistory> Histories { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
    }
}
