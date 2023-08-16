using assig_2.Models;
using assig_2.Services;
using assig_2.Services;
using Microsoft.AspNetCore.Mvc;


namespace assig_2.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class EmployController:ControllerBase
    {
        public EmployController()
        {
        }

        // GET all action
        [HttpGet]
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













