using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.DBContext;

namespace Todo.Data
{
    public static class Extensions
    {
        public static void ConnectDB(this IServiceCollection service, string connStr)
        {
            service.AddDbContext<TodoContext>(op => op.UseSqlServer(connStr));
        }
    }
}
