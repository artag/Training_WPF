using System.Collections.Generic;
using Todo.Models;

namespace Todo.Services
{
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem("Walk the dog"),
            new TodoItem("Buy some milk"),
            new TodoItem("Learn Avalonia", true),
        };
    }
}
