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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            this.Title = "Registrieren";
            brithDate.MaximumDate = DateTime.Today;
            
            
        }


        bool passwordOK = false, passwordSame = false, genderIsMale, genderSet = false, relationShipStatusSet = false, birthDateSet = false;
        RelationShipStatus rss = new RelationShipStatus();

        private void Anmelden_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Login();
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(password.Text.Length >= 4)
            {
                passwordOK = true;
            }
            else
            {
                passwordOK = false;
            }
        }

        private void confirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (password.Text.Equals(confirmPassword.Text))
            {
                passwordSame = true;
            }
            else
            {
                passwordSame = false;
            }
        }

        

        private void relationShipStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null)
            {
                return;
            }


            switch (picker.Items[picker.SelectedIndex])
            {
                case "Single":
                    rss = RelationShipStatus.single;
                    relationShipStatusSet = true;
                    break;
                case "Vergeben":
                    rss = RelationShipStatus.taken;
                    relationShipStatusSet = true;

                    break;
                case "Kompliziert":
                    rss = RelationShipStatus.complicated;
                    relationShipStatusSet = true;

                    break;
                default:
                    relationShipStatusSet = false;
                    return;

            }
            

        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null)
            {
                return;
            }
            

            switch (picker.Items[picker.SelectedIndex])
            {
                case "Männlich":
                    genderIsMale = true;
                    genderSet = true;
                    break;
                case "Weiblich":
                    genderIsMale = false;
                    genderSet = true;

                    break;
                default:
                    genderSet = false;

                    return;

            }
        }

        private static bool UsernameisAvailable(String u)
        {
            foreach (User user in DataWareHouse.User)
            {
                if (user.UserName.Equals(u))
                {
                    return false;
                }
            }
            return true;
        }

        private void registrieren_Clicked(object sender, EventArgs e)
        {
            if(UsernameisAvailable(username.Text) && username.Text != "" && username.Text != null && passwordOK && passwordSame && firstname.Text != "" && firstname.Text != null
                && lastname.Text != "" && lastname.Text != null && nickname.Text != "" && nickname.Text != null && genderSet && relationShipStatusSet)
            {
                DataWareHouse.addUser(new User(username.Text, password.Text, firstname.Text, lastname.Text, nickname.Text, brithDate.Date, genderIsMale, rss, Status.user));
                Application.Current.MainPage = new Login();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(genderSet);
                System.Diagnostics.Debug.WriteLine(relationShipStatusSet);
                System.Diagnostics.Debug.WriteLine(birthDateSet);


                DisplayAlert("Fehler", "Du hast wohl etwas falsch / nicht angegeben!" + "\n" + "Bitte versuche es erneut.", "OK");
            }
        }
    }
}