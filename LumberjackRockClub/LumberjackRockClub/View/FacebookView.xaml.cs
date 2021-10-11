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
    public partial class FacebookView : ContentPage
    {
        public FacebookView()
        {
            InitializeComponent();

            navegador.Source = "https://www.facebook.com/barbearialumberjackrs";
        }

        private void carregandoPagina(object sender, WebNavigatingEventArgs e)
        {
            lblStatus.Text = "Carregando Página...";
        }

        private void paginaCarregada(object sender, WebNavigatedEventArgs e)
        {
            lblStatus.Text = "Pronto";
        }
    }
}