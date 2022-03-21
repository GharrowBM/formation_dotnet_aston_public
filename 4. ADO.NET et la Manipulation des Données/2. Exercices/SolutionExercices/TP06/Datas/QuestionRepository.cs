using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP06.Classes;

namespace TP06.Datas
{
    internal class QuestionRepository : BaseRepository, IRepository<Question>
    {
        public Question Add(Question entity)
        {
            _context.Questions.Add(entity);
            if (_context.SaveChanges() > 0) return entity;
            return null;
        }

        public bool Delete(int id)
        {
            Question question = Get(id);

            if (question != null)
            {
                _context.Questions.Remove(question);
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public Question Get(int id)
        {
            return _context.Questions
                .Include(question => question.Posteur)
                .Include(question => question.Reponses).ThenInclude(reponse => reponse.Posteur)
                .Include(question => question.Reponses).ThenInclude(reponse => reponse.Commentaires).ThenInclude(commentaire => commentaire.Posteur)
                .FirstOrDefault(question => question.Id == id);
        }

        public List<Question> GetAll()
        {
            return _context.Questions
                .Include(question => question.Posteur)
                .Include(question => question.Reponses).ThenInclude(reponse => reponse.Posteur)
                .Include(question => question.Reponses).ThenInclude(reponse => reponse.Commentaires).ThenInclude(commentaire => commentaire.Posteur)
                .ToList();
        }

        public Question Update(int id, Question entity)
        {
            Question question = Get(id);

            if (question != null)
            {
                question.Title = entity.Title;
                question.Description = entity.Description;
                question.Score = entity.Score;

                _context.Questions.Update(question);
                if (_context.SaveChanges() > 0)
                {
                    return question;
                }
            }

            return null;
        }

        public Question AddOrUpdate(Question entity)
        {
            if (entity.Id == 0) return Add(entity);
            else return Update(entity.Id, entity);
        }
    }
}
