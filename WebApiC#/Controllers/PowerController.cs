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
    public async Task<ActionResult<List<PowerDTOResponse>>> GetAllFilms() {
         return Ok(await this._context.Powers.ToListAsync()); 
    }

    [HttpPost("post_power")]
    public async Task<ActionResult<List<PowerDTOResponse>>> PostNewFilm([FromBody] PowerDTORequest NewPower) 
    {
         if(NewPower == null) return BadRequest(); 
        Power power = ConvertUtils.RequestToPower(NewPower); 
        PowerDTOResponse powerDTOResponse = await ConvertUtils.PowertoResponse(power, this._context); 
        await this._context.Powers.AddAsync(power);  
        await this._context.SaveChangesAsync();
        return Ok(powerDTOResponse);
    }

       [HttpPut("update_Power")]
    public async Task<ActionResult<List<PowerDTOResponse>>> UpdateHero([FromBody] PowerDTORequest updatedPower, int IdToUpdated) 
    {
        if(updatedPower == null)  return BadRequest();
        Power powerUpdate = ConvertUtils.RequestToPower(updatedPower); 
        Power powerToUpdate = await this._context.Powers.FindAsync(IdToUpdated); 
        if(powerToUpdate == null) return BadRequest();
        if(powerUpdate.PowerName != null || powerUpdate.PowerName != "string") powerToUpdate.PowerName = powerUpdate.PowerName; 
        powerToUpdate.PowerIndice = powerUpdate.PowerIndice;  
        PowerDTOResponse powerDTOResponse = await ConvertUtils.PowertoResponse(powerToUpdate, this._context);
        this._context.Powers.Update(powerToUpdate); 
        await this._context.SaveChangesAsync();
        return Ok(powerDTOResponse);
    }
        
    [HttpDelete("delete_power")]
    public async Task<ActionResult<List<PowerDTOResponse>>> DeleteHero([FromBody] int Id) {
        if(Id == 0)  return BadRequest();
        var power = await this._context.Powers.FindAsync(Id); 
        if(power == null)  return BadRequest();
        this._context.Powers.Remove(power);
        this._context.SaveChanges();  
        return Ok(await this._context.Powers.ToListAsync()); 
    }
}