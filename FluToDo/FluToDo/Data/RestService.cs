using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FluToDo
{
    public class RestService : IRestService
    {
        private HttpClient _client;
        private const string Url = "http://aws1617-lt-sandbox-aws1617lt.c9users.io/api/v1/universities/";

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            var response = await _client.GetStringAsync($"{Url}");
            var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(response);
            return todoItems;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (isNewItem)
                {
                    response = await _client.PostAsync($"{Url}", content);
                }
                else
                {
                    response = await _client.PostAsync($"{Url}", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }
        }

        public async Task DeleteTodoItemAsync(string key)
        {
            try
            {
                var response = await _client.DeleteAsync($"{Url}{key}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }
        }
    }
}
