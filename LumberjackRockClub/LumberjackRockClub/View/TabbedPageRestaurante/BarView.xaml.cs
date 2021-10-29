using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using LumberjackRockClub.FirebaseServices;
using LumberjackRockClub.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumberjackRockClub.View.TabbedPageRestaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarView : ContentPage
    {    
        
        public BarView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            //base.OnAppearing();
            LancheService lanche = new LancheService();
            collectionview.ItemsSource = await lanche.RetornaHamburgers();
        }
        
    }
}