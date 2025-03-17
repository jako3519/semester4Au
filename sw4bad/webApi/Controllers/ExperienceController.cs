using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webApi.Models; 

namespace webApi.Controllers;

[ApiController]
[Route("api/[controller]")]  // route to access this controller, tager classen der har noget foran, feks experienceCOntroller
public class ExperiencesController : ControllerBase
{
    private static readonly List<Experience> Experiences = new()
    {
        new Experience { Name = "Cycling Short", Description = "20km", Price = 100 },
        new Experience { Name = "Cycling Medium", Description = "75km", Price = 200 },
        new Experience { Name = "Cycling Long", Description = "150km", Price = 300 }
    };

// herunder er endpoint 
    [HttpGet]
    public ActionResult<IEnumerable<Experience>> Get()
    {
        return Ok(Experiences);
    }
}

