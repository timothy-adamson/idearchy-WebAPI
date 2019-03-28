using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            var RequestDate = DateTime.ParseExact(
                    date,
                    "yyyy-MM-ddTHH:mm:ss.fffZ",
                    System.Globalization.CultureInfo.InvariantCulture);

            Func<DateTime, DateTime> GetWeekStart = (DateTime Date) => 
            {
                int Weekday = (int)Date.DayOfWeek;

                return new DateTime(
                    Date.Year,
                    Date.Month,
                    Date.Day - Weekday
                );
            };

            DateTime RequestWeekStart = GetWeekStart(RequestDate);
            DateTime CurrentWeekStart = GetWeekStart(DateTime.Today);

            var RequestTree = _context.Trees
                                .Where(t => t.Date.Date == RequestWeekStart.Date)
                                .Include(t => t.Ideas)
                                .FirstOrDefault();

            if (RequestTree != null)
            {
                List<IdeaDTO> IdeasDTO = new List<IdeaDTO>();
                
                if (RequestTree.Ideas != null)
                {
                    foreach(Idea idea in RequestTree.Ideas)
                    {
                        IdeasDTO.Add(new IdeaDTO() {
                            IdeaID = idea.IdeaID,
                            ParentID = idea.ParentID,
                            IsConundrum = idea.IsConundrum,
                            IdeaText = idea.IdeaText,
                            DateCreated = idea.DateCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                            FromCountry = idea.FromCountry,
                            Colour = idea.Colour,
                            Score = idea.Score
                        });
                    }
                }

                return IdeasDTO.ToList();;
            }
            else if (RequestWeekStart.Date == CurrentWeekStart.Date)
            {
                var NewTree = new Tree(){
                    Date = CurrentWeekStart.Date
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