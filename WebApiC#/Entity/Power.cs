public class Power 
{
    public string? PowerName { get; set; }
    public powerLevel powerLevel { get; set; }
}

public enum powerLevel {
    WEAK,
    MEDIUM, 
    STRONG, 
    OVER_POWERED,
    PLANET_EATER, 
    ETERNAL
} 