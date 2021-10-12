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
    public partial class PrincipalView : ContentView
    {
        public PrincipalView()
        {
            InitializeComponent();
        }

        public static implicit operator Page(PrincipalView v)
        {
            throw new NotImplementedException();
        }
    }
}