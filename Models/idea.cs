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
        public bool IsConundrum {get; set;}
        [StringLength(500), MinLength(1)]
        public string IdeaText {get;set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime DateCreated {get;set;}
        public string FromCountry {get;set;}
        public Int32? Colour {get;set;}

    }
}