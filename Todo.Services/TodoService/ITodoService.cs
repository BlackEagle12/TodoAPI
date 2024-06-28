using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services.TodoService
{
    public interface ITodoService
    {
        Task<List<Todo.Data.Models.Todo>> GetTodos();
        Task<Todo.Data.Models.Todo?> GetTodo(int id);
        Task<bool> AddTodo(Todo.Data.Models.Todo todo);
        Task<bool> UpdateTodo(int id, Todo.Data.Models.Todo todo);
        Task<bool> DeleteTodo(int id);
    }
}
