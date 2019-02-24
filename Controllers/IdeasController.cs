using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<string>> GetAll()
        {
            List<string> allTexts = new List<string>();

            foreach(Idea idea in _context.Ideas)
            {
                allTexts.Add(idea.IdeaText);
            }
            return allTexts;
        }

        [HttpGet("{id}")]
        public ActionResult<Idea> GetID(int id)
        {
            var idea = _context.Ideas.Find(id);
            if (idea == null)
            {
                return NotFound();
            }
            return idea;
        }
    } 
}