using System;
using System.Diagnostics;
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
            if (!File.Exists(DataWareHouse.isLoggedInPath))
            {
                File.Create("loggedIn.txt");
                if (File.Exists())
                {
                    Debug.WriteLine("\n \n \n \n \n \n \n nagga");
                }
                }
            bool loggedIn = DataWareHouse.IsLoggedIn;
            
            
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
