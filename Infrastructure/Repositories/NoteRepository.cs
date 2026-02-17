using Domain.Entities;
using Application.Services.Notes;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;

namespace Infrastructure.Repositories
{
    public class NoteRepository : INote
    {
        private readonly ApplicationDbContext _dbContext;
        public NoteRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Note> GetAllNotes()
        {
            List<Note> _notes = _dbContext.Notes.ToList();

            return _notes;
        }

        public Note GetNoteById(int id)
        {
            return _dbContext.Notes.FirstOrDefault(n => n.Id == id);
        }

       
    }
}