using System;

namespace IdeasAPI.Models
{
    public class IdeaDTO {

        public int IdeaID {get; set;}
        public int? ParentID {get; set;}
        public bool IsConundrum {get; set;}
        public string IdeaText {get;set;}
        public string DateCreated {get;set;}
        public string FromCountry {get;set;}
        public Int32? Colour {get;set;}
    }
}