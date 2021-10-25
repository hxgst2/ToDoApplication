using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.ToDo.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public int SortKey { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
