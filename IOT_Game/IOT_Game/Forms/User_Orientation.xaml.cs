using IOT_Game.GameServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace IOT_Game.Forms
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class User_Orientation : Page
	{
       public User _user;
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_user.RoleName=="User")
            {
                bntAdmin.Opacity = 0;
                btnQuestions.Opacity = 0;
                bntAdmin.IsEnabled = false;
                btnQuestions.IsEnabled = false;

            }
       
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _user = (User)e.Parameter;

        }
        public User_Orientation()
		{
			this.InitializeComponent();
		}

		private void MenuBtn_Click(object sender, RoutedEventArgs e)
		{
			this.MySplitView.IsPaneOpen = this.MySplitView.IsPaneOpen ? false : true;
		}

		private void btnQuestion(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(typeof(_Question));
		}

		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RdBtnGuvenliCikis_Click(object sender, RoutedEventArgs e)
		{
		   
		}

        private  void BntAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(AdminTransactions));
        }

        private void BtnRank_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(UserRank));
        }

        private void BtnOyna_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(User_Game));
        }

        private void BtnUserInformation_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(User_information),_user);
        }

        private void BtnQuestion_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(_Question));
        }
    }
}
