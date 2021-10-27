using LumberjackRockClub.FirebaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumberjackRockClub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualizarLanchesView : ContentPage
    {
        public VisualizarLanchesView()
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