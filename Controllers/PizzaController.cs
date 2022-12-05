using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if(pizza == null) return NotFound();
        return Ok(pizza);
    }

    [HttpPost]
    public IActionResult Post(Pizza pizza)
    {
        if (!ModelState.IsValid) return BadRequest();
        PizzaService.Add(pizza);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Pizza pizza)
    {
        PizzaService.Update(pizza);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        PizzaService.Delete(id);
        return Ok();
    }
}