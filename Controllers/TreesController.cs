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
            if (date == null){return BadRequest();}
            
            var RequestedDate = DateTime.ParseExact(
                    date,
                    "yyyy-MM-ddTHH:mm:ss.fffZ",
                    System.Globalization.CultureInfo.InvariantCulture);

            var RequestedTree = _context.Trees
                                .Where(t => t.Date.Date == RequestedDate.Date)
                                .FirstOrDefault();

            if (RequestedTree != null)
            {
                List<IdeaDTO> IdeasDTO = new List<IdeaDTO>();
                List<Idea> IdeasInTree = new List<Idea>();
                
                if (RequestedTree.IdeasIDs.Count() == 0)
                {
                    foreach(Idea idea in IdeasInTree)
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
                }

                return IdeasDTO.ToList();;
            }
            else if (RequestedDate.Date == DateTime.Today)
            {
                var NewTree = new Tree(){
                    Date = DateTime.Today,
                    IdeasIDs = new List<int>()
                };

                _context.Trees.Add(NewTree);
                _context.SaveChanges();

                return new List<IdeaDTO>().ToList();
            }
            else
            {
                return NotFound();
            }

        }
    } 
}