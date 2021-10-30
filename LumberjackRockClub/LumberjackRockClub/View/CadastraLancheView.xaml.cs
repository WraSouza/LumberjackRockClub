using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
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

namespace LumberjackRockClub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastraLancheView : ContentPage
    {       
        public CadastraLancheView()
        {
            InitializeComponent();
        }        
    }
}