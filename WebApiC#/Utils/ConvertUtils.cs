public class ConvertUtils
{

    public static Hero RequestToHero(HeroDTORequest dTORequest, List<Film> Films, List<Power> Powers)
    {
        if (dTORequest == null) return null;
        Hero hero = new Hero();
        if (dTORequest.HeroName != null) hero.Name = dTORequest.HeroName;
        if (dTORequest.RealHeroName != null) hero.RealName = dTORequest.RealHeroName;
        if (dTORequest.FilmsId != null)
        {
            foreach (int id in dTORequest.FilmsId)
            {
                if (id > 0)
                {
                    Film tmpFilm = Films[id - 1];
                    hero.Films.Add(tmpFilm);
                }
            }
        }
        if (dTORequest.PowersId != null)
        {
            foreach (int id in dTORequest.PowersId)
            {
                if (id > 0)
                {
                    Power tmpPower = Powers[id - 1];
                    hero.Powers.Add(tmpPower);
                }
            }
        }
        return hero;
    }
}