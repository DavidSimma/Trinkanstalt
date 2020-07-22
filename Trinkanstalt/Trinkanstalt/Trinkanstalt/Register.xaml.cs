using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trinkanstalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            this.Title = "Registrieren";
        }
        

        private async void Anmelden_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Login();
        }
    }
}