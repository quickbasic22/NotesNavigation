using NotesNavigation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesNavigation.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int _selectedStarValue;
        public Command<MainPage> LoadDataCommand { get; set; }
        public int SelectedStarValue
        {
            get => _selectedStarValue;
            set 
            { 
                _selectedStarValue = value; 
                OnPropertyChanged(); 
            }
        }

        public MainPageViewModel()
        {
           
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            Notes = new ObservableCollection<Note>();
            notes = new ObservableCollection<Note>();
            LoadDataCommand = new Command<MainPage>(LoadData);
            var myNotes = Notes.OrderByDescending(d => d.Date.Year).ToList();
            foreach (Note note in myNotes)
            {
                Notes.Add(note);
            }
            IsBusy = false;
        }

        public ICommand SelectedStarCommand => new Command<int>((selectedStarValue) =>
        {
            SelectedStarValue = selectedStarValue;
        });

        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy { get; private set; }
        public object SelectedItem { get; private set; }

        void LoadData(object obj)
        {
            var mainpage = obj as MainPage;
            var collection = mainpage.FindByName<CollectionView>("collectionView");
                       
            notes = new ObservableCollection<Note>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            try
            {
                foreach (var filename in files)
                {

                    notes.Add(new Note
                    {
                        Filename = filename,
                        Text = File.ReadAllText(filename),
                        Date = File.GetCreationTime(filename),
                        Stars = PickRandomStarValue()
                    }); ;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            collection.ItemsSource = Notes;
        }

        int PickRandomStarValue()
        {
            var random = new Random();
            
            return random.Next(0, 6);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
