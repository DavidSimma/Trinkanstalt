using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinkanstalt.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trinkanstalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Event : ContentPage
    {
        public Event()
        {
            InitializeComponent();
            if (!DataWareHouse.IsLoggedIn)
            {
                Navigation.PushAsync(new Login());
            }
            
        }
    }
}