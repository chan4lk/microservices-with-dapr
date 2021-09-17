using Microsoft.AspNetCore.Mvc;
using Dapr;

namespace dapr.microservice.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  
    [HttpGet("hello")]
    public string Get()
    {
        Console.WriteLine("Hello, World");

        return "Hello, World";
    }
}
