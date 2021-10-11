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
    public partial class InstagramView : ContentPage
    {
        public InstagramView()
        {
            InitializeComponent();

            navegador.Source = "https://www.instagram.com/rock_bar.bearia_lumberjack/";
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