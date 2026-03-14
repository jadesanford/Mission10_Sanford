//for building API controllers, models, database queries
using Microsoft.AspNetCore.Mvc;
using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Controllers;

[ApiController]

//route to match the controller name
[Route("[controller]")]
public class BowlersController : ControllerBase
{
    //a variable to store the database context
    private BowlingContext _context;

    //receives the database context
    public BowlersController(BowlingContext context)
    {
        _context = context;
    }

    //returns bowler data
    [HttpGet]
    public IActionResult Get()
    {
        var bowlers = _context.Bowlers
            //bowlers by team name
            .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
            .Select(b => new
            {
                //only the fields we want
                b.BowlerId,
                b.BowlerFirstName,
                b.BowlerMiddleInit,
                b.BowlerLastName,
                b.BowlerAddress,
                b.BowlerCity,
                b.BowlerState,
                b.BowlerZip,
                b.BowlerPhoneNumber,
                TeamName = b.Team.TeamName
            })
            //results to a list
            .ToList();
            
        //Return the bowler data
        return Ok(bowlers);
    }
}