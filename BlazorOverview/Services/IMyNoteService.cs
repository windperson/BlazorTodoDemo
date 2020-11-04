using BlazorOverview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public interface IMyNoteService
    {
        Task CreateAsync(MyNote myNote);

        Task DeleteAsync(MyNote myNote);

        Task<List<MyNote>> RetriveAsync();

        Task UpdateAsync(MyNote originMyNote, MyNote myNote);
    }
}
