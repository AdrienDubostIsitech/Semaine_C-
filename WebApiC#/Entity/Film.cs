public class Film
{
    public int Id { get; set; }
    public String FilmName { get; set; } = string.Empty;
    public String Date { get; set; } = string.Empty; 

    //Foreign Key
    public List<Hero> Heroes { get; set; }
}
