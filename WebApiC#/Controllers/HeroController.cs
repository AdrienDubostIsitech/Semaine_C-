using Microsoft.AspNetCore.Mvc; 

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

    [HttpGet]
    public ActionResult<List<Hero>> Get()
    {
        return Ok(heroes); 
    }

    
   // [HttpPost]
   // public ActionResult<List<Hero>> Post([FromBody] Hero RequestedHero) {
   //     var hero = heroes.Find(hero => RequestedHero.Id == hero.Id); 
   //     return Ok(); 
   // }

    [HttpPost]
    public async Task<ActionResult<List<Hero>>> CreateHero([FromBody]Hero newHero)
    {
        heroes.Add(newHero); 
        return Ok(heroes); 
    }
}