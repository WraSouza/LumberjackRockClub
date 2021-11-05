using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumberjackRockClub.View.TabbedPageRestaurante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuRestauranteView : FlyoutPage
    {
        public MenuRestauranteView()
        {
            InitializeComponent();
        }

        private void openRestaurantView(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new RestauranteView());
        }

        private void openBarView(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new BarView());
        }

        private void abrirTelaInicial(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new View.MainView());
        }

        private void openPromocoesView(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new PromocaoLanchesView());
        }
    }
}