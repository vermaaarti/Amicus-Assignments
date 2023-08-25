//using assig_2.Models;
using AssignmentAPI.Models;
//using assig_2.Services;
using AssignmentAPI.Services;
using Microsoft.AspNetCore.Mvc;


//namespace assig_2.Controllers;
namespace AssignmentAPI.Controllers;

[ApiController]
    [Route("/api")]
    public class EmployController:ControllerBase
    {
       

        // GET all action
        [HttpGet("/hello")]
        public ActionResult<List<Employ>> GetAll() =>
        EmployDetail.GetAll();


        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Employ> Get(int id)
        {
            var employ = EmployDetail.Get(id);

            if (employ == null)
                return NotFound();

            return employ;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Employ employ)
        {
            EmployDetail.Add(employ);
            return CreatedAtAction(nameof(Get), new { id = employ.Id }, employ);
        }


        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employ employ)
        {
            if (id != employ.Id)
                return BadRequest();

            var existingPizza = EmployDetail.Get(id);
            if (existingPizza is null)
                return NotFound();

            EmployDetail.Update(employ);

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = EmployDetail.Get(id);

            if (pizza is null)
                return NotFound();

            EmployDetail.Delete(id);

            return NoContent();
        }




    }













