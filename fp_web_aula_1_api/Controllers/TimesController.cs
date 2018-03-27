using fp_web_aula_1_core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fp_web_aula_1_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : Controller
    {
        private CopaContext _context;

        public TimesController(CopaContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public List<Time> Get()
        //{
        //    return _context.Times.ToList();
        //}

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Time>))]
        //[ProducesResponseType(404)]
        //public IActionResult Get()
        //{
        //    var times = _context.Times.ToList();
        //    if (times.Count == 0)
        //        return NotFound();

        //    return Ok(_context.Times.ToList());
        //}

        [HttpGet]
        public ActionResult<List<Time>> Get()
        {
            var times = _context.Times.ToList();
            if (times.Count == 0)
                return NotFound();

            return _context.Times.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Time> Get(int id)
        {
            var time = _context.Times.FirstOrDefault(t => t.Id == id);
            if (time == null)
                return NotFound();

            return Ok(time);
        }
        [HttpPost]
        public ActionResult<Time> Post(Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Add(time);
                _context.SaveChanges();
                return Created($"/api/times/{time.Id}", time);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Time> Put(int id, Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(time);
                _context.SaveChanges();
                return Ok(time);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var time = _context.Times.FirstOrDefault(t => t.Id == id);
            if (time == null)
                return NotFound();

            _context.Times.Remove(time);
            _context.SaveChanges();

            return NoContent();
        }
    }
}