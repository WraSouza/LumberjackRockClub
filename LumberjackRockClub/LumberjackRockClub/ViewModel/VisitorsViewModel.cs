using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LumberjackRockClub.ViewModel
{
    public class VisitorsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Command OpenBarber { get; set; }    
        public Command OpenRestaurant { get; set; }
        public Command OpenHamburger { get; set; }

        public VisitorsViewModel()
        {

        }

        public VisitorsViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            OpenHamburger = new Command(async () => await OpenHamburgersView());
            OpenBarber = new Command(async () => await OpenBarberView());
            OpenRestaurant = new Command( () => OpenRestaurantView());
        }

        private async Task OpenHamburgersView()
        {
            await Navigation.PushAsync(new View.HamburgersView());
        }

        private void OpenRestaurantView()
        {
              Application.Current.MainPage = new View.TabbedPageRestaurante.MenuRestauranteView();           
        }

        private async Task OpenBarberView()
        {
            await Navigation.PushAsync(new View.BarberSchedulesView());
        }
    }
}
