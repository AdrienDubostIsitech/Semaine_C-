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
    public async Task<ActionResult<List<HeroDTOResponse>>> GetHeroes()
    {
        return Ok(await this._context.Heroes.ToListAsync());
    }

    [HttpPost("get_hero_by_name")]
    public async Task<ActionResult<List<Hero>>> GetHeroesByName([FromBody] string name)
    {
        if (name == null || name == "string")
        {
            return BadRequest();
        }
        var heroes = await this._context.Heroes.ToListAsync();
        var hero = heroes.Find(hero => hero.Name == name);
        if (hero == null)
        {
            return BadRequest();
        }
        return Ok(hero);
    }

    [HttpPost("add_hero")]
    public async Task<ActionResult<List<HeroDTOResponse>>> CreateHero([FromBody] HeroDTORequest newHero)
    {
        if (newHero == null) return BadRequest();
        Hero hero = await ConvertUtils.RequestToHero(newHero, this._context); 
        HeroDTOResponse heroDTOResponse = await ConvertUtils.HeroToResponse(hero); 
        await this._context.Heroes.AddAsync(hero); 
        await this._context.SaveChangesAsync();
        return Ok(heroDTOResponse);
    }

    [HttpPut("update_hero")]
    public async Task<ActionResult<List<Hero>>> UpdateHero([FromBody] HeroDTORequest updatedHero)
    {
        if (updatedHero == null) return BadRequest();
        Hero HeroUpdate = await ConvertUtils.RequestToHero(updatedHero, this._context); 
        var hero = await this._context.Heroes.FindAsync(HeroUpdate.Id);
        HeroDTOResponse heroDTOResponse = await ConvertUtils.HeroToResponse(hero);  
        this._context.Heroes.Update(hero); 
        await this._context.SaveChangesAsync();
        return Ok(await this._context.Heroes.ToListAsync());
    }

    [HttpDelete("delete_hero")]
    public async Task<ActionResult<List<Hero>>> DeleteHero([FromBody] int Id)
    {
        if (Id == 0) return BadRequest();
        var hero = await this._context.Heroes.FindAsync(Id);
        if (hero == null) return BadRequest();
        this._context.Heroes.Remove(hero);
        this._context.SaveChanges();
        return Ok(await this._context.Heroes.ToListAsync());
    }
}