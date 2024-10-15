using DomainLayer.Models;
using Shared.Dto;

namespace ApplicationLayer.Interface;
public interface ITodoListServices
{
    public Task<TodoModel?> CreateTaskAsync(CreateTask task);
    public Task<GetTask?> GetTaskByIdAsync(int TaskId);
    public Task<TodoModel?> UpdateTaskAsync(int TaskId, UpdateTask request);
    public Task<TodoModel?> DeleteTaskAsync(int TaskId);

}