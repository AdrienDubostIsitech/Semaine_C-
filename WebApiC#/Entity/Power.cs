public class Power 
{
    public int Id { get; set; }
    public string PowerName { get; set; } = string.Empty; 

    public double PowerIndice { get; set; } 

    //Foreign key
    public List<Hero> Heroes { get; set; }
}