using BlazorOverview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public class MyNoteService : IMyNoteService
    {
        private List<MyNote> MyNotes { get; set; }

        public MyNoteService()
        {
            MyNotes = new List<MyNote>
            {
                new MyNote { Title = "買芭樂"},
                new MyNote { Title = "買頻果"},
                new MyNote { Title = "買西瓜"}
            };
        }

        public Task CreateAsync(MyNote myNote)
        {
            MyNotes.Add(myNote);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(MyNote myNote)
        {
            MyNotes.Remove(MyNotes.FirstOrDefault(x => x.Title == myNote.Title));
            return Task.CompletedTask;
        }

        public Task<List<MyNote>> RetriveAsync()
        {
            return Task.FromResult(MyNotes);
        }

        public Task UpdateAsync(MyNote originMyNote, MyNote myNote)
        {
            MyNotes.FirstOrDefault(x => x.Title == originMyNote.Title).Title = myNote.Title;
            return Task.CompletedTask;
        }
    }
}
