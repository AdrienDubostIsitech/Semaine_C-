public class HeroDTOResponse {
    public string HeroName { get; set; } = string.Empty; 
    public string HeroRealName { get; set; } = string.Empty; 
    public List<Film> Films { get; set; } = new List<Film>(); 
    public List<Power> Powers { get; set; } = new List<Power >();
}