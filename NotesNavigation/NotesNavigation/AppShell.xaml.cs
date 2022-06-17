using NotesNavigation.Views;
using Xamarin.Forms;

namespace NotesNavigation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
