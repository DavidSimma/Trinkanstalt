using System;
using System.IO;
using System.Xml.Serialization;
using Trinkanstalt.mainPages;
using Trinkanstalt.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trinkanstalt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Login();
            
        }

        protected override void OnStart()
        {
            if (!DataWareHouse.IsInitialized)
            {
                DataWareHouse.IsInitialized = true;
                DataWareHouse.Initialize();
                System.Diagnostics.Debug.WriteLine("Defaultdaten erstellt!");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
