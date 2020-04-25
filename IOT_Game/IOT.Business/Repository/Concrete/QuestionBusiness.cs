using IOT.Business.Repository.Abstract;
using IOT.Business.UnityOfWork;
using IOT.Entities;
using IOT.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Business.Repository.Concrete
{
    public class QuestionBusiness
    {
        private IRepository<Question> _QuestionRepository;
        private IRepository<QuestionViewModel>repository;

        private IUnitOfWork _QuestionUnitofwork;
        private DbContext _dbContext;
        public QuestionBusiness()
        {
            _dbContext = new GameDBEntities();
            _QuestionUnitofwork = new EFUnitOfWork(_dbContext);
            _QuestionRepository = _QuestionUnitofwork.GetRepository<Question>();
        }

        public List<Question> GetQuestion()
        {
            return _QuestionRepository.GetAll().ToList();
        }

        public void Insert(Question t)
        {
            _QuestionRepository.Insert(t);
            _QuestionUnitofwork.SaveChanges();
        }
        public void ViewInsert(QuestionViewModel t)
        {
            repository.Insert(t);
            _QuestionUnitofwork.SaveChanges();
        }

        public void Delete(int id)
        {
            _QuestionRepository.Delete(id);
            _QuestionUnitofwork.SaveChanges();
        }

        public void Update(Question t)
        {
            _QuestionRepository.Update(t);
            _QuestionUnitofwork.SaveChanges();
        }

        public void Delete(Question t)
        {
            _QuestionRepository.Delete(t);
            _QuestionUnitofwork.SaveChanges();
        }

        public Question Get(int id)
        {
            return _QuestionRepository.Get(x => x.DodID == id);
        }

       
    }
}
