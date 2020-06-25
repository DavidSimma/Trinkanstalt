using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Trinkanstalt.Models;
using Trinkanstalt.Views;
using Trinkanstalt.ViewModels;

namespace Trinkanstalt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LEDConnectionPage : ContentPage
    {

        LEDSteuernViewModel viewModel;
        public LEDConnectionPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LEDSteuernViewModel();
        }
    }
}