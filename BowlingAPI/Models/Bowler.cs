namespace BowlingAPI.Models;

//bowler class represents a bowler record in the database

public class Bowler
{
    public int BowlerId { get; set; }

    public string? BowlerFirstName { get; set; }

    public string? BowlerMiddleInit { get; set; }

    public string? BowlerLastName { get; set; }

    public string? BowlerAddress { get; set; }

    public string? BowlerCity { get; set; }

    public string? BowlerState { get; set; }

    public string? BowlerZip { get; set; }

    public string? BowlerPhoneNumber { get; set; }

//key that links the bowler to a team
    public int TeamId { get; set; }

    // nav property that connects the bowler to the team object
    public Team? Team { get; set; }
}