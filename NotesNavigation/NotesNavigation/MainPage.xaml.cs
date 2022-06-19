using NotesNavigation.Model;
using NotesNavigation.ViewModels;
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
        private MainPageViewModel _viewModel;
        
        //public static string FolderPath { get; private set; }
        public MainPage()
        {
            InitializeComponent();
           
            //try
            //{
            //    collectionView.BindingContext = Notes.OrderByDescending(d => d.Date.Year).ToList<Note>();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.ToString());
            //    Console.WriteLine(ex.ToString());
            //}
           
            BindingContext = _viewModel = new ViewModels.MainPageViewModel();

            //collectionView.HorizontalOptions = LayoutOptions.Start;
            //collectionView.VerticalOptions = LayoutOptions.StartAndExpand;
            //DisplayAlert(collectionView.BindingContext.ToString(), collectionView.BindingContext.ToString(), "Ok");

            //DisplayAlert(collectionView.VerticalOptions.ToString(), collectionView.Bounds.ToString(), "Ok");
            //DisplayAlert(collectionView.Visual.ToString(), collectionView.Bounds.ToString(), "Ok");

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            
        }
    }
}
