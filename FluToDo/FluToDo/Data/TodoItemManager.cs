using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluToDo.Data
{
    public class TodoItemManager
    {
        IRestService restService;

        public TodoItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }

        public Task DeleteTodoItemAsync(TodoItem item)
        {
            return restService.DeleteTodoItemAsync(item.Key);
        }
    }
}
