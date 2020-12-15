using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgerController : ControllerBase
  {
    private readonly BurgerService _bs;

    public BurgerController(BurgerService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Burger>> GetBurgers()
    {
      try
      {
        return Ok(_bs.GetBurgers());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Burger> GetOneBook(int id)
    {
      try
      {
        return Ok(_bs.GetOneBurger(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        return Ok(_bs.Create(newBurger));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Burger> UpdateBurger(int id, [FromBody] Burger updatedBurger)
    {
      try
      {
        return Ok(_bs.UpdateBurger(id, updatedBurger));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}