using Microsoft.AspNetCore.Mvc;
using YouTrackSharp;

namespace GraphQLTestingAPI.Controllers;
//[ApiController]
public class TestController : Controller
{
    [HttpGet("gay")]
    public async Task<IActionResult> Test()
    {
        var connection = new BearerTokenConnection("https://uralaminevtest.youtrack.cloud/",
            "perm:YWRtaW4=.NDgtMA==.JNEX2XT4LSQUUnU8PPtv8HSTrih3qo");
        var client = await connection.GetAuthenticatedApiClient();
        if (client == null)
            return BadRequest("Хуй");
        var projectService = connection.CreateProjectsService();
        var proj = await projectService.GetAccessibleProjects();
        return Ok(proj.FirstOrDefault().Name);
    }
}