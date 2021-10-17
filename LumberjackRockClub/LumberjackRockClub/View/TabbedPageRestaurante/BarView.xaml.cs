using Plugin.Media;
using System;
using System.Collections.Generic;
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

        private async void SalvarLanche(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                File = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                await StoreImages(file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}