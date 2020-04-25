using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using IOT.Business.Repository.Concrete;
using IOT.Entities;
using IOT.Entities.ViewModel;

namespace IOT.Service
{
    public class GameService : IGameService
    {
        UserBusiness userBusiness = new UserBusiness();
		QuestionBusiness questionBusiness = new QuestionBusiness();
        CategoryBusiness categoryBusiness = new CategoryBusiness();
        RankBusiness RankBusiness = new RankBusiness();
        DegreeOfDiffilcultBusiness dod = new DegreeOfDiffilcultBusiness();
        OptionBusiness OptionBusiness = new OptionBusiness();
        OuestionOptionBusiness QuestionOption = new OuestionOptionBusiness();

        public void AddQuestion(Question question)
		{
			questionBusiness.Insert(question);
		}

		public void AddUser(User user)
        {
            userBusiness.Insert(user);
        }

		public void EditQuestion(Question question)
		{
			questionBusiness.Update(question);
		}

		public void EditUser(User user)
        {
            userBusiness.Update(user);
        }

        public async Task<List<Category>> GetCategory(string categoryname)
        {           
            return categoryBusiness.GetAll(x => x.CategoryName == categoryname).ToList();
        }

        public async Task<List<Category>>GetCategory()
        {
            return  categoryBusiness.GetAll();
        }

        public async Task<List<DegreeOfDifficulty>> GetDod()
        {
            return  dod.GetAll();
        }

        public async Task<List<Option>> GetOption()
        {
            return OptionBusiness.GetAll();
        }

        public async Task<List<Question>>_GetQuestions()
		{
			return  questionBusiness.GetQuestion();
		}

        public async Task<List<RankViewModel>> GetRanks()
        {
            return await RankBusiness.Ranks();
        }

        public async Task<List<User>> GetUsers()
        {
            return userBusiness.GetAll();
        }

        public  User LoginUser(string username, string password)
        {
            return userBusiness.Get(x => x.UserName == username && x.Password == password);
        }

		public void RemoveQuestion(int id)
		{
			throw new NotImplementedException();
		}

		public void RemoveUser(int id)
        {
            userBusiness.Delete(id);
        }

        public bool UserControl(string Username)
        {
           return userBusiness.GetControl(x => x.UserName == Username);
        }


        public void AddQuestionView(QuestionViewModel question)
        {
            questionBusiness.ViewInsert(question);
        }

        public Task<List<Question>> GetByFilter(int id)
        {
            throw new NotImplementedException();
        }

        //public Task<List<Question>> GetByFilter(int id)
        //{
        //    return questionBusiness.Get(id);
        //}

        public async Task<List<QuestionViewModel>> QuestionVMRandom(int dodid)
        {
            List<QuestionViewModel> viewmodel = new List<QuestionViewModel>();

            List<Question> questionn = new List<Question>();
            Random rnd = new Random();

            var quest = questionBusiness.GetQuestion().Where(x=>x.DodID==dodid).ToList();
            int[] sayilar = new int[4] {5,5,5,5};

            for (int i = 0; i < 3; i++)
            {
                int randomyeni = rnd.Next(0, 3);
                if (sayilar.Contains(randomyeni))
                {
                   i--;
                }
                else
                {
                    sayilar[i] = randomyeni;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                questionn.Add(quest[sayilar[i]]);
            }

            //Cevap gelicek 
            foreach (var item in questionn)
            {
                var option = QuestionOption.GetAll().Where(x => x.QuestionID == item.QuestionID).ToList();

                viewmodel.Add(new QuestionViewModel
                {
                    DodID = item.DodID,
                    QuestionID = item.QuestionID,
                    QuestionName = item.QuestionName,
                    QuestionOption = option
                });
            }
            
            return viewmodel;
        }

        public Task<List<QuestionOptionView>> GetQuestionOptionViews()
        {
            return QuestionOption.QuestionOptions();
        }

        public void AddQuestionOption(QuestionOption questionOption)
        {
            QuestionOption.Insert(questionOption);
        }
    }
}
