using Microsoft.AspNetCore.Mvc;
using BowlingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BowlersController : ControllerBase
{
    private BowlingContext _context;

    public BowlersController(BowlingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var bowlers = _context.Bowlers
            .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
            .Select(b => new
            {
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
            .ToList();

        return Ok(bowlers);
    }
}