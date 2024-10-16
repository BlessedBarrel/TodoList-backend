using ApplicationLayer.Interface;
using DomainLayer.Dto;
using DomainLayer.Models;
using InfastructureLayer.Services.interfaces;
using Shared.Extension;

namespace ApplicationLayer.Services;

public class TodoServices : ITodoListServices
{
    private IRepositoryPattern<TodoModel> todoRepo; 
    private ILogger logger;
    public TodoServices(IRepositoryPattern<TodoModel> _todoService, ILogger<TodoModel> _logger)
    {
        todoRepo = _todoService;
        logger = _logger;
    }
    public async Task<TodoModel?> CreateTaskAsync(CreateTask task)
    {
        logger.LogInformation("Creating Task...");
        try
        {
            
            var existingTask = await todoRepo.FirstOrDefaultAsync(t => t.Name == task.Name);
            if(existingTask != null)
            {
                logger.LogError("Task with name already exists");
                return null;
            }

            
            var newTask = task.DeepClone<TodoModel>();

            if(newTask == null)
            {
                logger.LogError("Failed to deepclone");
                return null;
            }
            await todoRepo.AddAsync(newTask);
            await todoRepo.SaveChangesAsync();
            return newTask;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}