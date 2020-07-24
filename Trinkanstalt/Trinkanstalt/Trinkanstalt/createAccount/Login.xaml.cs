using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinkanstalt.mainPages;
using Trinkanstalt.models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trinkanstalt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private bool usernameExists = false, correctPasswort= false;
        User loginUser;
        public Login()
        {
            InitializeComponent();
            this.Title = "Login";
        }

        private  void register_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Register();
        }

        private void login_Clicked(object sender, EventArgs e)
        {
            if (usernameExists && correctPasswort)
            {
                Application.Current.MainPage = new SlideMenu();
            }
            else
            {
                DisplayAlert("Fehler", "Benutzername und/oder Passwort sind nicht richtig!", "OK");
            }

            System.Diagnostics.Debug.WriteLine(usernameExists);
            System.Diagnostics.Debug.WriteLine(correctPasswort);


        }

        private void passwort_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(passwort.Text);

            if (loginUser.UserPassword.Equals(passwort.Text))
            {
                correctPasswort = true;
            }
            else
            {
                correctPasswort = false;
            }
        }

        private void forgotPassword_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Passwort/Benutzername vergessen?", "Falls du dienen Benutzernamen und/oder dein Passwort vergessen hast, jedoch schon ein Konto hast, " +
                "wende dich bitte an den Entwickler dieser App!" + "\n" +
                "WhatsApp: 0677 61596328", "OK");
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(username.Text);
            
            foreach (User u in DataWareHouse.User)
            {
                System.Diagnostics.Debug.WriteLine(u.UserName);
                
                if (u.UserName == username.Text)
                {
                    usernameExists = true;
                    loginUser = u;
                }
                else
                {
                    usernameExists = false;
                }
                
                
            }
        }

        
    }
}