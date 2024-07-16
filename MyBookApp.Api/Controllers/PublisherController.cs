using Microsoft.AspNetCore.Mvc;
using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;

namespace MyBookApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPublisher([FromBody] PublisherRequest publisherRequest)
    {
        var publisherId = await _publisherService.AddPublisherAsync(publisherRequest);
        return Ok(publisherId);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPublisher(int id)
    {
        var publisher = await _publisherService.GetPublisherAsync(id);
        return Ok(publisher);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdatePublisherAsync(int id, PublisherRequest publisherRequest)
    {
        await _publisherService.UpdatePublisherAsync(id, publisherRequest);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePublisherAsync(int id)
    {
        await _publisherService.DeletePublisherAsync(id);
        return Ok();
    }
}