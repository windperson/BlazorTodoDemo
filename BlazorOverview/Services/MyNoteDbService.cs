using BlazorOverview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOverview.Services
{
    public class MyNoteDbService : IMyNoteService
    {
        private readonly MyNoteDbContext _myNoteDbContext;

        public MyNoteDbService(MyNoteDbContext myNoteDbContext)
        {
            _myNoteDbContext = myNoteDbContext;
        }

        public async Task CreateAsync(MyNote myNote)
        {
            await _myNoteDbContext.MyNotes.AddAsync(myNote);
            await _myNoteDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MyNote myNote)
        {
            var targetItem = await _myNoteDbContext.MyNotes.FirstOrDefaultAsync(x => x.Id == myNote.Id);
            if (targetItem != null)
            {
                _myNoteDbContext.MyNotes.Remove(targetItem);
                await _myNoteDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<MyNote>> RetriveAsync()
        {
            return await _myNoteDbContext.MyNotes.ToListAsync();
        }

        public async Task UpdateAsync(MyNote originMyNote, MyNote myNote)
        {
            var targetItem = await _myNoteDbContext.MyNotes.FirstOrDefaultAsync(x => x.Id == originMyNote.Id);
            if (targetItem != null)
            {
                targetItem.Title = myNote.Title;
                await _myNoteDbContext.SaveChangesAsync();
            }
        }
    }
}
