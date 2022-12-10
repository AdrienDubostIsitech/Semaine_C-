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
    public async Task<ActionResult<List<FilmDTOResponse>>> GetAllFilms() {
        return Ok(await this._context.Films.ToListAsync()); 
    }

    [HttpPost("post_film")]
    public async Task<ActionResult<List<FilmDTOResponse>>> PostNewFilm([FromBody] FilmDTORequest Newfilm) 
    {
        if(Newfilm == null) return BadRequest(); 
        Film film = ConvertUtils.RequestToFilm(Newfilm); 
        FilmDTOResponse filmDTOResponse = await ConvertUtils.FilmtoResponse(film, this._context); 
        await this._context.Films.AddAsync(film);  
        await this._context.SaveChangesAsync();
        return Ok(filmDTOResponse);
    }

    [HttpPut("update_film")]
    public async Task<ActionResult<List<FilmDTOResponse>>> UpdateHero([FromBody] FilmDTORequest updatedFilm, int IdToUpdated) 
    {
        if(updatedFilm == null)  return BadRequest();
        Film filmUpdate = ConvertUtils.RequestToFilm(updatedFilm); 
        Film filmToUpdate = await this._context.Films.FindAsync(IdToUpdated); 
        if(filmToUpdate == null) return BadRequest(); 
        if(filmUpdate.FilmName != null || filmUpdate.FilmName != "string") filmToUpdate.FilmName = filmUpdate.FilmName; 
        if(filmUpdate.Date != null || filmUpdate.Date == "string") filmToUpdate.Date = filmUpdate.Date;  
        FilmDTOResponse filmDTOResponse = await ConvertUtils.FilmtoResponse(filmToUpdate, this._context);
        this._context.Films.Update(filmToUpdate); 
        await this._context.SaveChangesAsync();
        return Ok(filmDTOResponse);
    }

    [HttpDelete("delete_film")]
    public async Task<ActionResult<List<FilmDTOResponse>>> DeleteHero([FromBody] int Id) {
        if(Id == 0)  return BadRequest();
        var film = await this._context.Films.FindAsync(Id); 
        if(film == null)  return BadRequest();
        this._context.Films.Remove(film);
        this._context.SaveChanges();
        return Ok(await this._context.Films.ToListAsync()); 
    }
}
    
    