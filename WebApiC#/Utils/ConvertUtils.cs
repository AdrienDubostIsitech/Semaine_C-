public class ConvertUtils
{
    public static async Task<Hero> RequestToHero(HeroDTORequest dTORequest, WebApiDbContext context)
    {
        if(dTORequest == null) return null;
        Hero hero = new Hero();
        if (dTORequest.HeroName != null) hero.Name = dTORequest.HeroName;
        if (dTORequest.RealHeroName != null) hero.RealName = dTORequest.RealHeroName;
        if (dTORequest.FilmsId.Count > 0)
        {
            foreach (int id in dTORequest.FilmsId)
            {
                if (id > 0)
                {
                    Film tmpFilm = await context.Films.FindAsync(id);
                    if(tmpFilm != null) hero.Films.Add(tmpFilm);
                }
            }
        }
        if (dTORequest.PowersId != null)
        {
            foreach (int id in dTORequest.PowersId)
            {
                if (id > 0)
                {
                    Power tmpPower = await context.Powers.FindAsync(id); 
                    if(tmpPower != null) hero.Powers.Add(tmpPower);
                }
            }
        }
        return hero;
    }

    public static async Task<HeroDTOResponse> HeroToResponse(Hero hero) {
        if (hero == null) return null;
        HeroDTOResponse dTOResponse = new HeroDTOResponse();
        if (hero.Name != null) hero.Name = dTOResponse.HeroName;
        if (hero.RealName != null) hero.RealName = dTOResponse.HeroRealName;
        if (hero.Films != null)
        {
            foreach (Film film in hero.Films)
            {
                if (film != null)
                {
                    dTOResponse.Films.Add(film); 
                }
            }
        }
        if (hero.Powers != null)
        {
            foreach (Power power in hero.Powers)
            {
                if (power != null)
                {
                    dTOResponse.Powers.Add(power); 
                }
            }
        }
        return dTOResponse;
    }

    public static Film RequestToFilm(FilmDTORequest dTORequest) {
        if(dTORequest == null) return null;
        Film film = new Film(); 
        if(dTORequest.Date != null) film.Date = dTORequest.Date; 
        if(dTORequest.Name != null) film.FilmName = dTORequest.Name; 
        return film; 
    }

    public static async Task<FilmDTOResponse> FilmtoResponse(Film film, WebApiDbContext context) {
        if(film == null) return null; 
        FilmDTOResponse dTOResponse = new FilmDTOResponse();
        if(film.FilmName != null) dTOResponse.Name = film.FilmName; 
        if(film.Date != null) dTOResponse.Date = film.Date; 
        if(context.Heroes != null) {
            foreach(Hero hero in context.Heroes) {
                if(hero.Films.Contains(film)) {
                    HeroDTOResponse heroDTOResponse = HeroToResponse(hero).Result; 
                    dTOResponse.Heroes.Add(heroDTOResponse); 
                }
            }
        }
        return dTOResponse; 
    }
    
    public static Power RequestToPower(PowerDTORequest dTORequest) {
        if(dTORequest == null) return null; 
        Power power = new Power(); 
        if(dTORequest.Name != null) power.PowerName = dTORequest.Name; 
        power.PowerIndice = dTORequest.StrengthIndice; 
        return power; 
    }    

    public static async Task<PowerDTOResponse> PowertoResponse(Power power, WebApiDbContext context) {
        if(power == null) return null; 
        PowerDTOResponse dTOResponse = new PowerDTOResponse();
        if(power.PowerName!= null) dTOResponse.Name = power.PowerName;  
        dTOResponse.StrengthIndice = power.PowerIndice;  
        if(context.Heroes != null) {
            foreach(Hero hero in context.Heroes) {
                if(hero.Powers.Contains(power)) {
                    HeroDTOResponse heroDTOResponse = HeroToResponse(hero).Result; 
                    dTOResponse.Heroes.Add(heroDTOResponse); 
                }
            }
        }
        return dTOResponse; 
    }    

}