using DB.ToDo.Database;
using DB.ToDo.Interfaces;
using DB.ToDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.ToDo.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoApplicationContext dbContext;

        public ToDoRepository(ToDoApplicationContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public async Task<ToDoItem> Get(int Id)
        {
            return await dbContext.ToDoItems?.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            return await dbContext.ToDoItems?.ToListAsync();
        }
        public async Task<ToDoItem> Create(ToDoItem toDoItem)
        {
            await dbContext.ToDoItems.AddAsync(toDoItem);
            await dbContext.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem> Delete(int Id)
        {
            var toDoItem = await dbContext.ToDoItems.FirstOrDefaultAsync(m => m.Id == Id);
            dbContext.ToDoItems.Remove(toDoItem);
            await dbContext.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem> Update(ToDoItem toDoItem)
        {
            dbContext.Update<ToDoItem>(toDoItem);
            await dbContext.SaveChangesAsync();
            return toDoItem;
        }
    }
}
