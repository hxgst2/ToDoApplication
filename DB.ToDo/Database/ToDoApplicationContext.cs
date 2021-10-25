using DB.ToDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.ToDo.Database
{
    public class ToDoApplicationContext:DbContext
    {
        public ToDoApplicationContext(DbContextOptions<ToDoApplicationContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
