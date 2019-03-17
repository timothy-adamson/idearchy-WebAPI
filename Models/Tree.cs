using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeasAPI.Models
{
    public class Tree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreeID {get;set;}
        public DateTime Date {get;set;}
        public virtual ICollection<Idea> Ideas {get; set;}
    }
}