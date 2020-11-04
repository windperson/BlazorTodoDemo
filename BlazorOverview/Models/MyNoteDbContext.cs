using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOverview.Models
{
    public class MyNoteDbContext : DbContext
    {
        public MyNoteDbContext(DbContextOptions<MyNoteDbContext> options) : base(options)
        {
        }

        public DbSet<MyNote> MyNotes { get; set; }
    }
}
