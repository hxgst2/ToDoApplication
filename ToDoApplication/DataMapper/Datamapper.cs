using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBModels = DB.ToDo.Models;
using UIModels = ToDoApplication.Models;
namespace ToDoApplication.DataMapper
{
    /// <summary>
    /// Service Class to Convert Data/Models in between UI/DB/Service Layer
    /// This Should be in Infrastructure Project.
    /// </summary>
    public static class Datamapper
    {
        #region DB Models to UI Models
        /// <summary>
        /// DB Item to UI Item
        /// </summary>
        /// <param name="dbItem"></param>
        /// <returns></returns>
        public static UIModels.ToDoItem uiToDoItem(this DBModels.ToDoItem dbItem)
        {
            if (dbItem == null) return null;
            return new UIModels.ToDoItem
            {
                Id = dbItem.Id,
                SortKey = dbItem.SortKey,
                Title = dbItem.Title,
                Description = dbItem.Description,
                DueDate = dbItem.DueDate
            };
        }
        
        /// <summary>
        /// DB Item List to UI Item List
        /// </summary>
        /// <param name="dbItems"></param>
        /// <returns></returns>
        public static IEnumerable<UIModels.ToDoItem> uiToDoItems(this IEnumerable<DBModels.ToDoItem> dbItems)
        {
            if (dbItems == null) return null;
            var items = dbItems.Select(x => x.uiToDoItem());
            return items;
        }
        #endregion

        #region UI Models to DB Models

        public static DBModels.ToDoItem dbToDoItem(this UIModels.ToDoItem uiModel)
        {
            if (uiModel == null) return null;
            return new DBModels.ToDoItem
            {
                Id = uiModel.Id,
                SortKey = uiModel.SortKey,
                Title = uiModel.Title,
                Description = uiModel.Description,
                DueDate = uiModel.DueDate,
            };
        }
        #endregion
    }
}
