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
        
        public VisitorsViewModel()
        {

        }

        public VisitorsViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            OpenBarber = new Command(async () => await OpenBarberView());
        }

        private async Task OpenBarberView()
        {
            await Navigation.PushAsync(new View.BarberSchedulesView());
        }
    }
}
