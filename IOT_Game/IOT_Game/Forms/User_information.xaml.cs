using IOT_Game.GameServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IOT_Game.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class User_information : Page
    {
        GameServiceClient client = new GameServiceClient();
        User user;
        public User_information()
        {
            //_user = user;

            this.InitializeComponent();
            

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            user = (User)e.Parameter;

        }
        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtLastName.Text) && string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtPassword.Password) && string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtTcNo.Text) && string.IsNullOrEmpty(txtPhoneNumber.Text) && string.IsNullOrEmpty(cmbGender.Text) && string.IsNullOrEmpty(cmbCity.Text) && string.IsNullOrEmpty(cmbJob.Text))
            {
                var msg = new MessageDialog("Eksik Veri Girişi Yaptınız Kontrol Ediniz.");
                await msg.ShowAsync();
            }
            else
            {
                var date = CdtDateBirth.Date;
                DateTime time = date.Value.DateTime;
                var formatedtime = time.ToString("dd.mm.yyyy");
                await client.EditUserAsync(new User
                {
                    UserID=user.UserID,
                    UserName = txtUsername.Text,
                    TcNo = txtTcNo.Text,
                    Phone = txtPhoneNumber.Text,
                    Password = txtPassword.Password,
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    Email = txtEmail.Text,
                    Gender = cmbGender.SelectedValue.ToString(),
                    City = cmbCity.SelectedValue.ToString(),
                    Job = cmbJob.SelectedValue.ToString(),
                    DateOfBirth = Convert.ToDateTime(time.ToShortDateString())

                });
                var ms = new MessageDialog("Güncelleme İşlemeniz Başarıyla Gerçekleşti");
                await ms.ShowAsync();
            }
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtPassword.Password = user.Password;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.Phone;
            txtTcNo.Text = user.TcNo;
            txtUsername.Text = user.UserName;
            cmbCity.SelectedValue = user.City;
            cmbGender.SelectedValue = user.Gender;
            cmbJob.SelectedValue = user.Job;
            CdtDateBirth.Date = user.DateOfBirth;
        }
    }
}
