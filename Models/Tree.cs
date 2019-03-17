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
        public List<int> IdeasIDs {get;set;}
        [ForeignKey("IdeasIDs")]
        public virtual ICollection<Idea> Ideas {get; set;}
    }
}