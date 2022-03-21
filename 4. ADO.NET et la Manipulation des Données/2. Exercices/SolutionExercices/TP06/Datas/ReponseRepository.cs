using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP06.Classes;

namespace TP06.Datas
{
    internal class ReponseRepository : BaseRepository, IRepository<Reponse>
    {
        public Reponse Add(Reponse entity)
        {
            _context.Reponses.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return entity;
            }

            return null;
        }

        public Reponse AddOrUpdate(Reponse entity)
        {
            if (entity.Id == 0) return Add(entity);
            else return Update(entity.Id, entity);
        }

        public bool Delete(int id)
        {
            Reponse reponse = Get(id);
            if (reponse != null)
            {
                _context.Reponses.Remove(reponse);
                if(_context.SaveChanges() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public Reponse Get(int id)
        {
            return _context.Reponses
                .Include(reponse => reponse.Posteur)
                .Include(reponse => reponse.Commentaires).ThenInclude(commentaire => commentaire.Posteur)
                .FirstOrDefault(question => question.Id == id);
        }

        public List<Reponse> GetAll()
        {
            return _context.Reponses
                .Include(reponse => reponse.Posteur)
                .Include(reponse => reponse.Commentaires).ThenInclude(commentaire => commentaire.Posteur)
                .ToList();
        }

        public Reponse Update(int id, Reponse entity)
        {
            Reponse reponse = Get(id);

            if (reponse != null)
            {
                reponse.Title = entity.Title;
                reponse.Score = entity.Score;
                reponse.Description = entity.Description;
                
                _context.Reponses.Update(reponse);

                if (_context.SaveChanges() > 0)
                {
                    return reponse;
                }
            }

            return null;
        }
    }
}
