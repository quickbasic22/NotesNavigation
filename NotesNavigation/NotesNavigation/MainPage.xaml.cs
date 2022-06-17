using NotesNavigation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesNavigation
{
    public partial class MainPage : ContentPage
    {
        private List<Note> notes;
        public List<Note> Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }
        //public static string FolderPath { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = null;
            notes = new List<Note>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            try
            {
                foreach (var filename in files)
                {

                    notes.Add(new Note
                    {
                        Filename = filename,
                        Text = File.ReadAllText(filename),
                        Date = File.GetCreationTime(filename)
                    });
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                collectionView.BindingContext = notes.OrderByDescending(d => d.Date.Year).ToList<Note>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            //collectionView.HorizontalOptions = LayoutOptions.Start;
            //collectionView.VerticalOptions = LayoutOptions.StartAndExpand;
            //DisplayAlert(collectionView.BindingContext.ToString(), collectionView.BindingContext.ToString(), "Ok");

            //DisplayAlert(collectionView.VerticalOptions.ToString(), collectionView.Bounds.ToString(), "Ok");
            //DisplayAlert(collectionView.Visual.ToString(), collectionView.Bounds.ToString(), "Ok");

        }
    }
}
