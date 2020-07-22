using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trinkanstalt.mainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
            this.Master = new Event();
            this.Detail = new NavigationPage(new Shop());
            this.Detail = new NavigationPage(new TotalInventory());
            this.Detail = new NavigationPage(new Locations());
            this.Detail = new NavigationPage(new Account());

        }
    }
}