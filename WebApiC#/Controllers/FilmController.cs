    using Microsoft.AspNetCore.Mvc; 
using System.Net; 
namespace WebApiC_.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase 
{
    private readonly WebApiDbContext _context; 

    public FilmController(WebApiDbContext apiDbContext) 
    {
        this._context = apiDbContext;
    }

    [HttpGet("get_films")]
    public async Task<ActionResult<List<Film>>> GetAllFilms() {
        return Ok(await this._context.Films.ToListAsync()); 
    }

    [HttpPost("post_film")]
    public async Task<ActionResult<List<Film>>> PostNewFilm([FromBody] Film Newfilm) 
    {
        if(Newfilm == null) return BadRequest(); 
        await this._context.Films.AddAsync(Newfilm); 
        return Ok(await this._context.Films.ToListAsync()); 
    }

    [HttpPut("update_film")]
    public async Task<ActionResult<List<Film>>> UpdateHero([FromBody] Film updatedFilm) 
    {
        if(updatedFilm == null)  return BadRequest();
        var film = await this._context.Films.FindAsync(updatedFilm.Id);
        if(film == null)  return BadRequest();
        if(film.FilmName != null) film.FilmName = updatedFilm.FilmName; 
        if(film.Date != null) film.Date = updatedFilm.Date; 
        this._context.Films.Update(film);  
        await this._context.SaveChangesAsync(); 
        return Ok(await this._context.Films.ToListAsync()); 
    }

    [HttpDelete("delete_film")]
    public async Task<ActionResult<List<Film>>> DeleteHero([FromBody] int Id) {
        if(Id == 0)  return BadRequest();
        var film = await this._context.Films.FindAsync(Id); 
        if(film == null)  return BadRequest();
        this._context.Films.Remove(film);
        this._context.SaveChanges();  
        return Ok(await this._context.Films.ToListAsync()); 
    }
}
    
    