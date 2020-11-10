using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinProject.helpers;

namespace XamarinProject
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()  
        {  
  
            base.OnAppearing();  
            await firebaseHelper.GetAllNotes();
            
        }
    }
}