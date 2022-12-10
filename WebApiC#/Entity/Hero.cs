using System.Collections; 
public class Hero
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string RealName { get; set; } = string.Empty; 

    public List<Film> Films { get; set; } = new List<Film>(); 
    public List<Power> Powers { get; set; }  = new List<Power>(); 

}