using IOT_Game.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class _Question : Page
    {
        GameServiceClient client = new GameServiceClient();
        List<Category> categoryList = new List<Category>();
        List<Option> optionsList = new List<Option>();
        List<DegreeOfDifficulty> dodList = new List<DegreeOfDifficulty>();
        List<QuestionOptionView> optionViews = new List<QuestionOptionView>();
        public _Question()
        {
            this.InitializeComponent();
            var getquestion = new ObservableCollection<QuestionOptionView>();
            getquestion = client.GetQuestionOptionViewsAsync().Result;
            foreach (var item in getquestion)
            {
                optionViews.Add(item);
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //var categories = new ObservableCollection<Category>();
            //categories = client.GetCategoryAsync().Result;
            //foreach (var item in categories)
            //{
            //    QuestionCategory.Items.Add(item.CategoryName);

            //}
            //var options = new ObservableCollection<Option>();
            //options = client.GetOptionAsync().Result;
            //foreach (var item2 in options)
            //{
            //    TrueOption.Items.Add(item2.OptionName);

            //}

            //    var dod = new ObservableCollection<DegreeOfDifficulty>();
            //    dod = client.GetDodAsync().Result;
            //    foreach (var item3 in dod)
            //    {
            //        QuestionLevel.Items.Add(item3.DodName);
            //    }

        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TrueOption.SelectedIndex == 0 || QuestionLevel.SelectedIndex == 0 || string.IsNullOrEmpty(txtQuestion.Text) || string.IsNullOrEmpty(OptionA.Text) || string.IsNullOrEmpty(OptipnB.Text) || string.IsNullOrEmpty(OptipnC.Text) || string.IsNullOrEmpty(OptipnD.Text) || string.IsNullOrEmpty(QuestionCategory.Text))
            {
                var msg = new MessageDialog("Eksik Veri Girişi Yaptınız.");
                await msg.ShowAsync();
            }
            else
            {
                await client.AddQuestionAsync(new Question
                {
                    CategoryID = Convert.ToInt32(QuestionCategory.SelectedIndex + 1),
                    DodID = Convert.ToInt32(QuestionLevel.SelectedIndex + 1),
                    QuestionName = txtQuestion.Text,
                });
                var get = new ObservableCollection<Question>();
                get = client._GetQuestionsAsync().Result;
                var queoptions = new ObservableCollection<QuestionOption>();
                //queoptions = client.().Result;
                foreach (var item in get)
                {
                    await client.AddQuestionViewAsync(new QuestionViewModel
                    {
                        DodID = item.DodID,
                        QuestionID = item.QuestionID,
                        QuestionName=item.QuestionName


                    });
                }
                for (int i = 1; i < 4; i++)
                {

                    //if (TrueOption.SelectedItem=="A")
                    //{
                    //    var quest = client._GetQuestionsAsync().Result.Where(x => x.QuestionName == txtQuestion.Text && x.DodID == Convert.ToInt32 (QuestionLevel.SelectedIndex + 1 ) && x.CategoryID= Convert.ToInt32(QuestionCategory.SelectedIndex + 1)));
                    //    client.AddQuestionOptionAsync(new QuestionOption { OptionID = i, AnswerStatus = true, AnswerText = OptionA.Text, QuestionID = s});
                    //}
                }

                var ms = new MessageDialog("Kayıt İşlemeniz Başarıyla Gerçekleşti.");
                await ms.ShowAsync();
            }

        }

        private void Delete(object sender, DoubleTappedRoutedEventArgs e)
        {
        }
    }
}

