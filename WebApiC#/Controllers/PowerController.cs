using Microsoft.AspNetCore.Mvc; 
using System.Net; 
namespace WebApiC_.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerController : ControllerBase {
    private readonly WebApiDbContext _context; 

    public PowerController(WebApiDbContext apiDbContext) 
    {
        this._context = apiDbContext;
    }

    [HttpGet("get_powers")]
    public async Task<ActionResult<List<Film>>> GetAllFilms() {
        return Ok(await this._context.Powers.ToListAsync()); 
    }

    [HttpPost("post_power")]
    public async Task<ActionResult<List<Film>>> PostNewFilm([FromBody] Power NewPower) 
    {
        if(NewPower == null) return BadRequest(); 
        await this._context.Powers.AddAsync(NewPower); 
        return Ok(await this._context.Powers.ToListAsync()); 
    }

       [HttpPut("update_Power")]
    public async Task<ActionResult<List<Hero>>> UpdateHero([FromBody] Power updatedPower) 
    {
        if(updatedPower == null)  return BadRequest();
        var power = await this._context.Powers.FindAsync(updatedPower.Id);
        if(power == null)  return BadRequest();
        if(power.PowerName != null) power.PowerName = updatedPower.PowerName; 
        if(power.powerLevel != null) power.powerLevel = updatedPower.powerLevel; 
        this._context.Powers.Update(power);  
        this._context.SaveChanges(); 
        return Ok(await this._context.Powers.ToListAsync()); 
    }
        
    [HttpDelete("delete_power")]
    public async Task<ActionResult<List<Power>>> DeleteHero([FromBody] int Id) {
        if(Id == 0)  return BadRequest();
        var power = await this._context.Powers.FindAsync(Id); 
        if(power == null)  return BadRequest();
        this._context.Powers.Remove(power);
        this._context.SaveChanges();  
        return Ok(await this._context.Powers.ToListAsync()); 
    }
}