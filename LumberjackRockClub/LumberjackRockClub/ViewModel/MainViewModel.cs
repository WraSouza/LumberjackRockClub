using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LumberjackRockClub.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public Command OpenLogin { get; set; }
        public Command OpenCreatAccount { get; set; }

        public Command OpenFacebook { get; set; }
        public Command OpenInstagram { get; set; }

        public MainViewModel()
        {
        }

        public MainViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            OpenLogin = new Command(async () => await OpenLoginView());
            OpenCreatAccount = new Command(async () => await OpenCreatAccountView());
            OpenFacebook = new Command( async () => await OpenFacebookView());
            OpenInstagram = new Command( async () => await OpenInstagramView());
        }

        private async Task OpenInstagramView()
        {
            await Navigation.PushAsync(new View.InstagramView());
        }

        private async Task OpenFacebookView()
        {
            await Navigation.PushAsync(new View.FacebookView());
        }

        private async Task OpenLoginView()
        {
            await Navigation.PushAsync(new View.LoginView());
        }

        private async Task OpenCreatAccountView()
        {
            await Navigation.PushAsync(new View.CreateAccountView());
        }
    }
}
