using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections; 
using System.Collections.Generic; 
using System.Linq; 
using IdeasAPI.Models;  

namespace IdeasAPI.Controllers {

    [Route("api/[controller]")]     
    [ApiController]     
    public class TreesController : ControllerBase     
    {        
        private readonly IdeaContext _context;          

        public TreesController(IdeaContext context)         
        {            
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<IdeaDTO>> GetTree([FromQuery] string date)
        {
            var RequestedDate = DateTime.ParseExact(
                    date,
                    "yyyy-MM-ddTHH:mm:ss.fffZ",
                    System.Globalization.CultureInfo.InvariantCulture);

            var RequestedTree = from tree in _context.Trees
                                where tree.Date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") == date
                                select tree.Ideas;

            if (RequestedTree != null)
            {
                List<IdeaDTO> IdeasDTO = new List<IdeaDTO>();

                foreach(Idea idea in RequestedTree)
                {
                    IdeasDTO.Add(new IdeaDTO() {
                        IdeaID = idea.IdeaID,
                        ParentID = idea.ParentID,
                        IsConundrum = idea.IsConundrum,
                        IdeaText = idea.IdeaText,
                        DateCreated = idea.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        FromCountry = idea.FromCountry,
                        Colour = idea.Colour
                    });
                }

                return IdeasDTO.ToList();;
            }
            else if (RequestedDate.Date == DateTime.Today)
            {
                var NewTree = new Tree(){
                    Date = DateTime.Today,
                    IdeasIDs = new List<int>()
                };

                return new List<IdeaDTO>().ToList();
            }
            else
            {
                return NotFound();
            }

        }
    } 
}