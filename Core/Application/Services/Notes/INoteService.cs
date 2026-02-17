using Domain.Entities;

namespace Application.Services.Notes
{
    public interface INoteService
    {
        Note GetNoteById(int id);
        
        List<Note> GetAllNotes();
    }
}