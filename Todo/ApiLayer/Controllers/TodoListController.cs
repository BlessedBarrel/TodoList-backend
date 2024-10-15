using ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto;

namespace Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
    private ITodoListServices todoService;
    public TodoListController(ITodoListServices _todoListServices)
    {
        todoService =
        _todoListServices;
    }

    [HttpPost]
    [Route("CreateTask")]
    public async Task<IActionResult> CreateTask (CreateTask request)
    {
        //validation here 

        var result = await todoService.CreateTaskAsync(request);
        if(result== null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(CreateTask), new { id = result.Id }, result);
        
    }

    [HttpGet("{TaskId}")]
    public async Task<IActionResult> GetTaskById ([FromRoute] int TaskId)
    {
        var result = await todoService.GetTaskByIdAsync(TaskId);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);

    }

    [HttpPut("{TaskId}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int TaskId, [FromBody] UpdateTask request)
    {
        //validation
        var result = await todoService.UpdateTaskAsync(TaskId, request);
        
        if(result == null)
        return NotFound();
        
        return NoContent();
    }

    [HttpDelete("{TaskId}")]
    public async Task<IActionResult> DeleteTask([FromRoute] int TaskId)
    {
        var result = await todoService.DeleteTaskAsync(TaskId);
        if(result == null)
            return NotFound();
        return NoContent();
    }

}