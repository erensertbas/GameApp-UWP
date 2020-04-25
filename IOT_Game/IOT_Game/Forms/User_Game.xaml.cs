using IOT_Game.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI;
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
    public sealed partial class User_Game : Page
    {
        GameServiceClient client = new GameServiceClient();

        MediaPlayer player;
        bool playing;
        int QuestionNumber = 0;
        int sayacc = 0;
       
        ObservableCollection<QuestionViewModel> question;

        public User_Game()
        {
            player = new MediaPlayer();
            this.InitializeComponent();
            // lstQuestion.Items.Add(question[0].QuestionName);
            List<DegreeOfDifficulty> degrees = new List<DegreeOfDifficulty>();
            
        }

        DispatcherTimer phone = new DispatcherTimer();
        DispatcherTimer dt = new DispatcherTimer();

        private void TxtQuestion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void CleanButton()
        {
            increment = 15;
            dt.Start();
            
        }

        private async void BtnA_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "UYARI",
                Content = "A Seçeneği Seçildi! Son Kararınız mı?",
                PrimaryButtonText = "Son Kararım",
                CloseButtonText = "İptal"
            };
            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

                dt.Stop();
                //  btnA.Background = new SolidColorBrush(Colors.Yellow);


                if (increment > 1)
                {

                    if (question[sayacc].QuestionOption.Where(x => x.OptionID == 1).FirstOrDefault().AnswerStatus == true)
                    {
                        QuestionNumber++;
                        if (QuestionNumber == 1)
                        {
                            CleanButton();
                            btn500.Background = new SolidColorBrush(Colors.Yellow);
                        }
                        else if (QuestionNumber == 2)
                        {
                            CleanButton();
                            btn1k.Background = new SolidColorBrush(Colors.Yellow);
                        }
                        else if (QuestionNumber == 3)
                        {
                            CleanButton();
                            btn2k.Background = new SolidColorBrush(Colors.Yellow);
                        }


                        if (QuestionNumber == 3 || QuestionNumber == 6 || QuestionNumber == 9)
                        {
                            question = null;
                        }
                        sayacc++;
                        if (sayacc > 2)
                        {
                            sayacc = 0;
                        }
                        YeniSoru(QuestionNumber);
                       // btnA.Background = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        var dogrucevap = question[sayacc].QuestionOption.Where(x => x.AnswerStatus == true).FirstOrDefault();
                        btnA.Background = new SolidColorBrush(Colors.Red);
                        var ms = new MessageDialog("Cevap Yanlış! \n Doğru Cevap : "+ dogrucevap.AnswerText.ToString());
                        await ms.ShowAsync();
                        dt.Stop();
                    }
                  }
                else
                {
                    var ms = new MessageDialog("Süre Doldu! Yanıt vermediniz!");
                    await ms.ShowAsync();
                }
            }


        }

        private async void BtnB_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "UYARI",
                Content = "B Seçeneği Seçildi! Son Kararınız mı?",
                PrimaryButtonText = "Son Kararım",
                CloseButtonText = "İptal"
            };
            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

                dt.Stop();
                //  btnB.Background = new SolidColorBrush(Colors.Yellow);
                if (increment>1)
               {

                if (question[sayacc].QuestionOption.Where(x => x.OptionID == 2).FirstOrDefault().AnswerStatus == true)
                {
                    QuestionNumber++;
                    if (QuestionNumber == 1)
                    {
                        CleanButton();
                        btn500.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (QuestionNumber == 2)
                    {
                        CleanButton();
                        btn1k.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (QuestionNumber == 3)
                    {
                        CleanButton();
                        btn2k.Background = new SolidColorBrush(Colors.Yellow);
                    }
                   // btnB.Background = new SolidColorBrush(Colors.Green);
                    if (QuestionNumber == 3 || QuestionNumber == 6 || QuestionNumber == 9)
                    {
                        question = null;
                    }
                    sayacc++;
                    if (sayacc > 2)
                    {
                        sayacc = 0;
                    }
                    YeniSoru(QuestionNumber);
                 

                }
                    else
                    {
                   

                        var dogrucevap = question[sayacc].QuestionOption.Where(x => x.AnswerStatus == true).FirstOrDefault();
                        btnB.Background = new SolidColorBrush(Colors.Red);
                        var ms = new MessageDialog("Cevap Yanlış! \n Doğru Cevap : " + dogrucevap.AnswerText.ToString());
                        dt.Stop();
                    }
                }
                else
                {
                    var ms = new MessageDialog("Süre Doldu! Yanıt vermediniz!");
                    await ms.ShowAsync();
                }

               

            }
        }

        private async void BtnC_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "UYARI",
                Content = "C Seçeneği Seçildi! Son Kararınız mı?",
                PrimaryButtonText = "Son Kararım",
                CloseButtonText = "İptal"
            };
            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
               

                dt.Stop();
                //  btnC.Background = new SolidColorBrush(Colors.Yellow);
                if (increment>1)
                {

                if (question[sayacc].QuestionOption.Where(x => x.OptionID == 3).FirstOrDefault().AnswerStatus == true)
                {
                    QuestionNumber++;
                    if (QuestionNumber==1)
                    {
                        CleanButton();
                        btn500.Background= new SolidColorBrush(Colors.Yellow);
                    }
                   else if (QuestionNumber == 2)
                    {
                        CleanButton();
                        btn1k.Background = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (QuestionNumber == 3)
                    {
                        CleanButton();
                        btn2k.Background = new SolidColorBrush(Colors.Yellow);
                    }
                   
                   // btnD.Background = new SolidColorBrush(Colors.Green);
                    if (QuestionNumber == 3 || QuestionNumber == 6 || QuestionNumber == 9)
                    {
                        question = null;
                    }
                    sayacc++;
                    if (sayacc > 2)
                    {
                        sayacc = 0;
                    }
                    YeniSoru(QuestionNumber);
                    
                    btnD.Background = new SolidColorBrush(Colors.MediumPurple);

                }
                else
                {
                  
                        dt.Stop();

                        var dogrucevap = question[sayacc].QuestionOption.Where(x => x.AnswerStatus == true).FirstOrDefault();
                        btnC.Background = new SolidColorBrush(Colors.Red);
                        var ms = new MessageDialog("Cevap Yanlış! \n Doğru Cevap : " + dogrucevap.AnswerText.ToString());
                    }
                }

                else
                {
                    var ms = new MessageDialog("Süre Doldu! Yanıt vermediniz!");
                    await ms.ShowAsync();
                }
            }

        }

        private async void BtnD_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "UYARI",
                Content = "D Seçeneği Seçildi! Son Kararınız mı?",
                PrimaryButtonText = "Son Kararım",
                CloseButtonText = "İptal"
            };
            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                
                dt.Stop();
                //  btnD.Background = new SolidColorBrush(Colors.Yellow);
                if (increment > 1)
                {

                    if (question[sayacc].QuestionOption.Where(x => x.OptionID == 4).FirstOrDefault().AnswerStatus == true)
                    {
                        QuestionNumber++;
                        if (QuestionNumber == 1)
                        {
                            CleanButton();
                            btn500.Background = new SolidColorBrush(Colors.Yellow);
                        }
                        else if (QuestionNumber == 2)
                        {
                            CleanButton();
                            btn1k.Background = new SolidColorBrush(Colors.Yellow);
                        }
                        else if (QuestionNumber == 3)
                        {
                            CleanButton();
                            btn2k.Background = new SolidColorBrush(Colors.Yellow);
                        }


                     //   btnD.Background = new SolidColorBrush(Colors.Green);
                        if (QuestionNumber == 3 || QuestionNumber == 6 || QuestionNumber == 9)
                        {
                            question = null;
                        }
                        sayacc++;
                        if (sayacc > 2)
                        {
                            sayacc = 0;
                        }
                        YeniSoru(QuestionNumber);
                        //Bekleme Delay Verilcek

                    }
                    else
                    {
                        var dogrucevap = question[sayacc].QuestionOption.Where(x => x.AnswerStatus == true).FirstOrDefault();
                        btnD.Background = new SolidColorBrush(Colors.Red);
                        var ms = new MessageDialog("Cevap Yanlış! \n Doğru Cevap : " + dogrucevap.AnswerText.ToString());
                        await ms.ShowAsync();
                    }
                }
                else
                {
                    var ms = new MessageDialog("Süre Doldu! Yanıt vermediniz!");
                    await ms.ShowAsync();
                }
            }
        }


        void YeniSoru(int sorusayi)
        {
            if (sorusayi<3)
            {
                if (question==null)
                {
                    question = client.QuestionVMRandomAsync(1).Result;
                }
            }
            else if (sorusayi<6 && sorusayi>2)
            {
                if (question == null)
                {
                    question = client.QuestionVMRandomAsync(2).Result;
                }
            }
            else if (sorusayi < 9 && sorusayi > 5)
            {
                if (question == null)
                {
                    question = client.QuestionVMRandomAsync(3).Result;
                }
            }
            else if (sorusayi < 12 && sorusayi > 8)
            {
                if (question == null)
                {
                    question = client.QuestionVMRandomAsync(4).Result;
                }
            }
            txtQuestion.Text = question[sayacc].QuestionName.ToString();

            foreach (var item in question[sayacc].QuestionOption)
            {
                if (item.OptionID==1)
                {
                    btnA.Content = item.AnswerText;
                }
                else if (item.OptionID == 2)
                {
                    btnB.Content = item.AnswerText;
                }
                else if (item.OptionID == 3)
                {
                    btnC.Content = item.AnswerText;
                }
                else if (item.OptionID == 4)
                {
                    btnD.Content = item.AnswerText;
                }
                else
                {
                    //Hata mesajı
                }
            }
                  
        }
        private void BtnBasla_Click(object sender, RoutedEventArgs e)
        {

            
            // Soruları Çek Foreachle dön içinde for döndür !
            YeniSoru(QuestionNumber);


            player.Source = null;
            playing = false;

            myPopup.IsOpen = false;
            dt.Start();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            player.Source = null;
            playing = false;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("yarisma.mp3");
            player.Source = MediaSource.CreateFromStorageFile(file);

            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            if (myPopup.IsOpen)
            {

                player.AutoPlay = true;

            }
        }
        private int increment = 15;
        private int PhoneIncrement = 20;

        private void Dt_Tick(object sender, object e)
        {
          

            increment--;
            Second.Text = increment.ToString();
            
            if (increment < 5)
            {
                Second.Foreground = new SolidColorBrush(Colors.Red);

            }
            if (increment == 0)
            {
                dt.Stop();
                
            }
            

        }

        private void TxtSoru_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneClose_Click(object sender, RoutedEventArgs e)
        {
            phoneJokerPop.IsOpen = false;
            phone.Stop();
            dt.Start();
        }

        private void PhoneJoker_Click(object sender, RoutedEventArgs e)
        {
            phoneJoker.IsEnabled = false;
            phone.Start();
            phone.Interval = TimeSpan.FromSeconds(1);
            phone.Tick += Phone_Tick;
            phoneJokerPop.IsOpen = true;
            dt.Stop();

        }

        private async void Phone_Tick(object sender, object e)
        {
            
            PhoneIncrement--;
            phoneSecond.Text = PhoneIncrement.ToString();
            if (PhoneIncrement == 15)
            {

                var phoneJoker= question[sayacc].QuestionOption.Where(x => x.AnswerStatus == true).FirstOrDefault();

                var ms = new MessageDialog("Öncellikle iyi yarışmalar !  Bence cevap " + phoneJoker.AnswerText.ToString() + "  ama tam emin değilim.");
                await ms.ShowAsync();
            }
            if (PhoneIncrement < 5)
            {
                phoneSecond.Foreground = new SolidColorBrush(Colors.Red);

            }
            if (PhoneIncrement == 0)
            {
                phone.Stop();
                phoneJokerPop.IsOpen = false;
                dt.Start();
            }
          

        }
    }
}
