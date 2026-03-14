//the namespace for the Models folder
namespace BowlingAPI.Models;

//represents a bowling team in the database
public class Team
{
    public int TeamId { get; set; }

    public string? TeamName { get; set; }

    //relationship between Team and Bowler
    public List<Bowler>? Bowlers { get; set; }
}