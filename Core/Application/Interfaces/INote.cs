using Domain.Entities;

namespace Application.Interfaces
{
    public interface INoteService
    {
        public List<Note> GetAllNotes();
        public Note GetNoteById(int id);
    }
}