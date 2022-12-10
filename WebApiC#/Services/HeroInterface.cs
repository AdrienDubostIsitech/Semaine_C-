public interface HeroInterface {

    Hero GetHeroByName(string name); 
    HeroDTOResponse addHero(HeroDTORequest dTORequest); 
    HeroDTOResponse updateHero(HeroDTORequest dTORequest, int Id); 
    List<HeroDTOResponse> deleteHero(int Id);    
}