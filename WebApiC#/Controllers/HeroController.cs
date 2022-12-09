using Microsoft.AspNetCore.Mvc; 
using System.Net; 
namespace WebApiC_.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private static List<Hero> heroes = new List<Hero>
    {
        new Hero {Id = 1, Name = "IronMan", RealName = "Tony Stark"},
        new Hero {Id = 2, Name = "Captain America", RealName = "Steve Rogers"}, 
        new Hero {Id = 3, Name = "Thor", RealName = "Thor"}, 
        new Hero {Id = 4, Name = "Hulk", RealName = "Bruce Banner"}
    }; 
    private readonly WebApiDbContext _context; 

    public HeroController(WebApiDbContext apiDbContext) 
    {
        this._context = apiDbContext;
    }

    [HttpGet("get_heroes")]
    public async Task<ActionResult<List<Hero>>> GetHeroes()
    { 
        return Ok(await this._context.Heroes.ToListAsync()); 
    }

    [HttpPost("get_hero_by_name")]
    public async Task<ActionResult<List<Hero>>> GetHeroesByName([FromBody] string name)
    { 
        if(name == null || name == "string"){ 
            return BadRequest();
        }
        var heroes = await this._context.Heroes.ToListAsync();
        var hero = heroes.Find(hero => hero.Name == name);
        if(hero == null) {
            return BadRequest();
        }
        return Ok(hero); 
    }

    [HttpPost("add_hero")]
    public async Task<ActionResult<List<Hero>>> CreateHero([FromBody]Hero newHero)
    {
        await this._context.Heroes.AddAsync(newHero);
        await this._context.SaveChangesAsync(); 
        return Ok(await this._context.Heroes.ToListAsync()); 
    }

    [HttpPut("update_hero")]
    public async Task<ActionResult<List<Hero>>> UpdateHero([FromBody] Hero updatedHero) 
    {
        if(updatedHero == null)  return BadRequest();
        var hero = await this._context.Heroes.FindAsync(updatedHero.Id);
        if(hero == null)  return BadRequest();
        if(hero.Name != null) hero.Name = updatedHero.Name; 
        if(hero.RealName != null) hero.RealName = updatedHero.RealName; 
        //if(hero.LFilms != null) hero.LFilms = updatedHero.LFilms; 
        //if(hero.LPowers != null) hero.LPowers = updatedHero.LPowers; 
        this._context.Heroes.Update(hero);  
        await this._context.SaveChangesAsync(); 
        return Ok(); 
    }

    [HttpDelete("delete_hero")]
    public async Task<ActionResult<List<Hero>>> DeleteHero([FromBody] int Id) {
        if(Id == 0)  return BadRequest();
        var hero = await this._context.Heroes.FindAsync(Id); 
        if(hero == null)  return BadRequest();
        this._context.Heroes.Remove(hero);
        this._context.SaveChanges();  
        return Ok(); 
    }
}