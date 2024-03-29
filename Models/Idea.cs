using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeasAPI.Models
{
    public class Idea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdeaID {get; set;}
        public int? ParentID {get; set;}
        [ForeignKey("ParentID")]
        public virtual Idea ParentIdea {get; set;}
        [InverseProperty("ParentIdea")]
        public virtual ICollection<Idea> ChildrenIdeas {get; set;}
        public int TreeID {get;set;}
        [ForeignKey("TreeID")]
        public virtual Tree Tree {get;set;}
        public bool IsConundrum {get; set;}
        [StringLength(500), MinLength(1)]
        public string IdeaText {get;set;}
        public DateTime DateCreated {get;set;}
        public string FromCountry {get;set;}
        public Int32? Colour {get;set;}
        public int Score {get;set;}

    }
}