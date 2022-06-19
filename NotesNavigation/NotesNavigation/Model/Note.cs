using System;

namespace NotesNavigation.Model
{
    public class Note
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Stars { get; set; }
    }
}
