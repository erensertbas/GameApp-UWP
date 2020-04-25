﻿using IOT.Entities;
using IOT.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Service
{
    
    [ServiceContract]
    public interface IGameService
    {
        //User
        [OperationContract]
        User LoginUser(string username, string password);
        [OperationContract]
        Task<List<User>>GetUsers();
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void RemoveUser(int id);
        [OperationContract]
        void EditUser(User user);
        [OperationContract]
        bool UserControl(string Username);

		//Question
		[OperationContract]
		Task<List<Question>> _GetQuestions();
		[OperationContract]
		void AddQuestion(Question question);
        [OperationContract]
        void AddQuestionView(QuestionViewModel question);
        [OperationContract]
		void RemoveQuestion(int id);
		[OperationContract]
		void EditQuestion(Question question);
        [OperationContract]
        Task<List<Question>> GetByFilter(int id);
        [OperationContract]
        Task<List<QuestionViewModel>> QuestionVMRandom(int dodid);

        //Category
        [OperationContract]
        Task<List<Category>>GetCategory();
        Task<List<Category>>GetCategory(string categoryname);

        //Ranks
        [OperationContract]
        Task<List<RankViewModel>>GetRanks();

        //DOD
        [OperationContract]
        Task<List<DegreeOfDifficulty>> GetDod();

        //option
        [OperationContract]
        Task<List<Option>> GetOption();
        [OperationContract]
        void AddQuestionOption(QuestionOption questionOption);
        //QuestionOptions
        [OperationContract]
        Task<List<QuestionOptionView>>GetQuestionOptionViews();


    }
}
