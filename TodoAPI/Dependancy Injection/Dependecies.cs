using Todo.Repo;
using Todo.Services.TodoService;

namespace TodoAPI
{
    public static class Dependecies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped(typeof(IGenericRepo<>),typeof(Repo<>));
        }
    }
}
