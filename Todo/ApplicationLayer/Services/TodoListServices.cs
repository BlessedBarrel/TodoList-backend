using ApplicationLayer.Interface;
using DomainLayer.Models;
using InfastructureLayer.Services.interfaces;
using Shared.Dto;
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

    public async Task<GetTask?> GetTaskByIdAsync(int TaskId)
    {
        logger.LogInformation("Creating Task...");
        try
        {
            var existingTask = await todoRepo.GetByIdAsync(TaskId);
            if(existingTask != null)
            {
                var task = existingTask.DeepClone<GetTask>();
                return task;
            }
            return null;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public async Task<TodoModel?> UpdateTaskAsync(int TaskId, UpdateTask request)
    {
        logger.LogInformation("Creating Task...");
        try
        {
            var existingTask = await todoRepo.FirstOrDefaultAsync(x => x.Id == TaskId);
            if(existingTask == null)
            {
                logger.LogError("Task not found");
                return null;
            }
            request.CopyPropertiesTo(existingTask);
            todoRepo.UpdatechangesAsync(existingTask);
            await todoRepo.SaveChangesAsync();
            return existingTask;
            // Check for same name? 

        }
        catch (System.Exception e)
        {
           Console.WriteLine(e.Message);
            return null;
        }
    }

    public async Task<TodoModel?> DeleteTaskAsync(int TaskId)
    {
        logger.LogInformation("Deleting Task...");
        try
        {
            var existingTask = await todoRepo.GetByIdAsync(TaskId);
            if(existingTask == null)
            {
                logger.LogError("Task with  id {TaskId} not found", TaskId);
                return null;
            }
            todoRepo.Delete(existingTask);
            await todoRepo.SaveChangesAsync();
            return existingTask;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }



}
            //Make a TodoTask that has more tasks inside it.
            //Set unique name rule in database 