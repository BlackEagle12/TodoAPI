using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.DBContext;
using Todo.Data.Models;
using Todo.Repo;

namespace Todo.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly IGenericRepo<Todo.Data.Models.Todo> _todoRepo;
        public TodoService(
                IGenericRepo<Todo.Data.Models.Todo> todoRepo
            )
        {
            _todoRepo = todoRepo;
        }

        public async Task<bool> AddTodo(Data.Models.Todo todo)
        {
            await _todoRepo.InsertAsync(todo);
            return true;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            await _todoRepo.DeleteAsync(id);
            return true;
        }

        public async Task<Data.Models.Todo?> GetTodo(int id)
        {
            return await _todoRepo.FindByIdAsync(id);
        }

        public async Task<List<Data.Models.Todo>> GetTodos()
        {
            return await _todoRepo.GetAllAsync();
        }

        public async Task<bool> UpdateTodo(int id, Data.Models.Todo todo)
        {
            await _todoRepo.UpdateAsync(todo);
            return true;
        }
    }
}
