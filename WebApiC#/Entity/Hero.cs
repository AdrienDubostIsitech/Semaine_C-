using System.Collections; 
public class Hero
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string RealName { get; set; } = string.Empty; 

    public List<Film> Films { get; set; }
    public List<Power> Powers { get; set; } 

}