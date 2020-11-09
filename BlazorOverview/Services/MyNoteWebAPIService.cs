using BlazorOverview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public class MyNoteWebAPIService : IMyNoteService
    {
        public HttpClient Client { get; }

        public MyNoteWebAPIService(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task CreateAsync(MyNote myNote)
        {
            var content = JsonSerializer.Serialize(myNote);
            using(var stringContent = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json))
            {
                await Client.PostAsync("/api/MyNote", stringContent);
            }
        }

        public async Task<List<MyNote>> RetriveAsync()
        {
            var content = await Client.GetStringAsync("/api/MyNote");
            var allMyNotes = JsonSerializer.Deserialize<List<MyNote>>(content);
            return allMyNotes;
        }

        public async Task UpdateAsync(MyNote originMyNote, MyNote myNote)
        {
            var content = JsonSerializer.Serialize(myNote);
            using (var stringContent = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json))
            {
                await Client.PutAsync($"/api/MyNote/{myNote.Id}", stringContent);
            }
        }

        public async Task DeleteAsync(MyNote myNote)
        {
            await Client.DeleteAsync($"/api/MyNote/{myNote.Id}");
        }
    }
}
