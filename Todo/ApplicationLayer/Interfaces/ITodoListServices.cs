using DomainLayer.Dto;
using DomainLayer.Models;

namespace ApplicationLayer.Interface;
public interface ITodoListServices
{
    public Task<TodoModel?> CreateTaskAsync(CreateTask task);

}