using Domain.Entities;
using Application.Interfaces;
using Application.Services.Notes;


 namespace Application.Services.Notes
{
    public class NoteService : INoteService
    {
        private readonly INote _notes;

         public NoteService(INote note)
        {
            _notes = note;
        }
        public List<Note> GetAllNotes()
        {
            List<Note> notes = _notes.GetAllNotes();
            
        return notes;
        }

       public Note GetNoteById(int id)
        {
            return _notes.GetNoteById(id);
        }
        
    }
    public interface INote
        {
            List<Note> GetAllNotes();
            Note GetNoteById(int id);
        }   
}

