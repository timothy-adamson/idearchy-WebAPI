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
        
        //Return All ideas in the database as DTOs
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
                Colour = i.Colour,
                Score = i.Score
            };

            return IdeasDTO.ToList();;
        }

        // Get a single idea in the database as a DTO
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
                Colour = i.Colour,
                Score = i.Score
            };

            if (i == null)
            {
                return NotFound();
            }
            return ideaDTO;
        }

        // Add a new Idea to the database if it is valid
        [HttpPost]
        public ActionResult<IdeaDTO> Add([FromBody]IdeaDTO newIdea)
        {
            if (ModelState.IsValid)
            {
                //Date manipulation enables counting of weeks and allocation of posts to the correct tree
                DateTime CurrentWeekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);

                DateTime CurrentTreeDate = new DateTime(
                    CurrentWeekStart.Year,
                    CurrentWeekStart.Month,
                    CurrentWeekStart.Day
                );

                //Users can only add to the current tree
                var TodaysTree = _context.Trees
                            .Where(t => t.Date.Date == CurrentTreeDate.Date)
                            .FirstOrDefault();

                var dbIdea = new Idea() {
                    TreeID = TodaysTree.TreeID,
                    ParentID = newIdea.ParentID,
                    IsConundrum = newIdea.IsConundrum,
                    IdeaText = newIdea.IdeaText,
                    DateCreated = DateTime.ParseExact(
                        newIdea.DateCreated,"yyyy-MM-ddTHH:mm:ss.fffZ",System.Globalization.CultureInfo.InvariantCulture),
                    FromCountry = newIdea.FromCountry,
                    Colour = newIdea.Colour,
                    Score = newIdea.Score
                };

                _context.Ideas.Add(dbIdea);
                _context.SaveChanges();

                //Return the new idea as a DTO on success
                var returnIdea = new IdeaDTO() { 
                    IdeaID = dbIdea.IdeaID,
                    ParentID = dbIdea.ParentID,
                    IsConundrum = dbIdea.IsConundrum,
                    IdeaText = dbIdea.IdeaText,
                    DateCreated = dbIdea.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    FromCountry = dbIdea.FromCountry,
                    Colour = dbIdea.Colour,
                    Score = dbIdea.Score
                };

                return Ok(returnIdea);
            }
            else
            {
                return BadRequest();
            }
        }

        // Update the score of a particular Idea
        [HttpPatch("{id}")]
        public ActionResult<IdeaDTO> AddScore(int id,[FromBody]bool status)
        {
            var dbIdea = _context.Ideas.Find(id);

            // Status is defined by whether user has previously voted on this item
            if (dbIdea != null)
            {
                if (status)
                {
                    dbIdea.Score = dbIdea.Score + 1;
                }
                else
                {
                    dbIdea.Score = dbIdea.Score - 1;
                }
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            var returnIdea = new IdeaDTO() { 
                IdeaID = dbIdea.IdeaID,
                ParentID = dbIdea.ParentID,
                IsConundrum = dbIdea.IsConundrum,
                IdeaText = dbIdea.IdeaText,
                DateCreated = dbIdea.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                FromCountry = dbIdea.FromCountry,
                Colour = dbIdea.Colour,
                Score = dbIdea.Score
            };

            return Ok(returnIdea);
        }
    } 
}