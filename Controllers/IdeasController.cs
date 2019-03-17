using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections; 
using System.Collections.Generic; 
using System.Linq; 
using IdeasAPI.Models;  

namespace IdeasAPI.Controllers {

    [Route("api/[controller]")]     
    [ApiController]     
    public class IdeasController : ControllerBase     
    {        
        private readonly IdeaContext _context;          

        public IdeasController(IdeaContext context)         
        {            
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<List<IdeaDTO>> GetAll()
        {
            var IdeasDTO = from i in _context.Ideas select new IdeaDTO(){

                IdeaID = i.IdeaID,
                ParentID = i.ParentID,
                IsConundrum = i.IsConundrum,
                IdeaText = i.IdeaText,
                DateCreated = i.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                FromCountry = i.FromCountry,
                Colour = i.Colour
            };

            return IdeasDTO.ToList();;
        }

        [HttpGet("{id}")]
        public ActionResult<IdeaDTO> GetID(int id)
        {
            var i = _context.Ideas.Find(id);
            
            var ideaDTO = new IdeaDTO() { 
                IdeaID = i.IdeaID,
                ParentID = i.ParentID,
                IsConundrum = i.IsConundrum,
                IdeaText = i.IdeaText,
                DateCreated = i.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                FromCountry = i.FromCountry,
                Colour = i.Colour
            };

            if (i == null)
            {
                return NotFound();
            }
            return ideaDTO;
        }

        [HttpPost]
        public ActionResult<Idea> Add([FromBody]IdeaDTO newIdea)
        {
            if (ModelState.IsValid)
            {
                var TodaysTree = _context.Trees
                            .Where(t => t.Date.Date == DateTime.Today)
                            .FirstOrDefault();

                var dbIdea = new Idea() {
                    TreeID = TodaysTree.TreeID,
                    ParentID = newIdea.ParentID,
                    IsConundrum = newIdea.IsConundrum,
                    IdeaText = newIdea.IdeaText,
                    DateCreated = DateTime.ParseExact(
                        newIdea.DateCreated,"yyyy-MM-ddTHH:mm:ss.fffZ",System.Globalization.CultureInfo.InvariantCulture),
                    FromCountry = newIdea.FromCountry,
                    Colour = newIdea.Colour
                };

                _context.Ideas.Add(dbIdea);
                _context.SaveChanges();

                var returnIdea = new IdeaDTO() { 
                    IdeaID = dbIdea.IdeaID,
                    ParentID = dbIdea.ParentID,
                    IsConundrum = dbIdea.IsConundrum,
                    IdeaText = dbIdea.IdeaText,
                    DateCreated = dbIdea.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    FromCountry = dbIdea.FromCountry,
                    Colour = dbIdea.Colour
                };

                return Ok(returnIdea);
            }
            else
            {
                return BadRequest();
            }
        }
    } 
}