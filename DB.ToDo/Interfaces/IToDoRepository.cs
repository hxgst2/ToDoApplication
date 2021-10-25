using DB.ToDo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.ToDo.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoItem>> GetAll();
        Task<ToDoItem> Get(int Id);
        Task<ToDoItem> Create(ToDoItem toDoItem);
        Task<ToDoItem> Update(ToDoItem toDoItem);
        Task<ToDoItem> Delete(int Id);
    }
}
