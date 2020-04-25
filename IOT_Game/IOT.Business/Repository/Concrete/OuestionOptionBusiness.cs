using IOT.Business.Repository.Abstract;
using IOT.Entities;
using IOT.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Business.Repository.Concrete
{
    public class OuestionOptionBusiness : IDatabaseBusiness<QuestionOption>
    {
        GameDBEntities db = new GameDBEntities();
        public void Delete(QuestionOption entity)
        {
            db.QuestionOptions.Attach(entity);
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var questionOption = Get(id);
            db.QuestionOptions.Attach(questionOption);
            db.Entry(questionOption).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public QuestionOption Get(int id)
        {
            return db.QuestionOptions.Find(id);
        }

        public QuestionOption Get(Expression<Func<QuestionOption, bool>> expression)
        {
            return db.QuestionOptions.Where(expression).FirstOrDefault();
        }

        public List<QuestionOption> GetAll()
        {
            return db.QuestionOptions.ToList();
        }

        public List<QuestionOption> GetAll(Expression<Func<QuestionOption, bool>> expression)
        {
            return db.QuestionOptions.Where(expression).ToList();
        }

        public void Insert(QuestionOption entity)
        {
            db.QuestionOptions.Add(entity);
            db.SaveChanges();
        }

        public void Update(QuestionOption entity)
        {
            db.QuestionOptions.Attach(entity);
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public async Task<List<QuestionOptionView>>QuestionOptions()
        {
            using (GameDBEntities db = new GameDBEntities())
            {
                var questionOptions = new List<QuestionOptionView>().ToList();
                var result = from qo in db.QuestionOptions
                             join q in db.Questions on qo.QuestionID equals q.QuestionID
                             join o in db.Options on qo.OptionID equals o.OptionID
                             select new
                             {
                                 qo.QuestionOptionID,
                                 qo.QuestionID,
                                 qo.OptionID,
                                 qo.AnswerStatus,
                                 qo.AnswerText,
                                 q.QuestionName,
                                 o.OptionName
                             };

                foreach (var que in result)
                {
                    questionOptions.Add(new QuestionOptionView
                    {
                        QuestionID = que.QuestionID,
                        OptionID = que.OptionID,
                        QuestionOptionID = que.QuestionOptionID,
                        AnswerStatus = que.AnswerStatus,
                        AnswerText = que.AnswerText,
                        QuestionName = que.QuestionName,
                        OptionName = que.OptionName
                    });
                }
                return questionOptions;
            }
        }
    }
}
    
