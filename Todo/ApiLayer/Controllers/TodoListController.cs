using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Interface;
using DomainLayer.Dto;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> CreateTask (CreateTask task)
    {
        //validation here 

        var result = await todoService.CreateTaskAsync(task);
        if(result== null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(CreateTask), new { id = result.Id }, result);
        
    }
}