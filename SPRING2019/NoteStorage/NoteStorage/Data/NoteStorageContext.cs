using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoteStorage.Models
{
    public class NoteStorageContext : DbContext
    {
        public NoteStorageContext (DbContextOptions<NoteStorageContext> options)
            : base(options)
        {
        }

        public DbSet<NoteStorage.Models.Note> Note { get; set; }
    }
}
