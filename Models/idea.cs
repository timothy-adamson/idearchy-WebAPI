using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeasAPI.Models
{
    public class Idea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdeaID {get; set;}
        public string IdeaText {get;set;}
        public DateTime TimeCreated {get;set;}
        public string FromCountry {get;set;}
    }
}