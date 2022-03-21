using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP06.Classes;

namespace TP06.Datas
{
    internal class CommentaireRepository : BaseRepository, IRepository<Commentaire>
    {
        public Commentaire Add(Commentaire entity)
        {
            _context.Commentaires.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return entity;
            }

            return null;
        }

        public Commentaire AddOrUpdate(Commentaire entity)
        {
            if (entity.Id == 0) return Add(entity);
            else return Update(entity.Id, entity);
        }

        public bool Delete(int id)
        {
            Commentaire commentaire = Get(id);

            if (commentaire != null)
            {
                _context.Commentaires.Remove(commentaire);

                if(_context.SaveChanges() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public Commentaire Get(int id)
        {
            return _context.Commentaires.Include(commentaire => commentaire.Posteur).FirstOrDefault(commentaire => commentaire.Id == id);
        }

        public List<Commentaire> GetAll()
        {
            return _context.Commentaires.Include(commentaire => commentaire.Posteur).ToList();
        }

        public Commentaire Update(int id, Commentaire entity)
        {
            Commentaire commentaire = Get(id);

            if (commentaire != null)
            {
                commentaire.Title = entity.Title;
                commentaire.Description = entity.Description;
                commentaire.Score = entity.Score;

                _context.Commentaires.Update(commentaire);

                if (_context.SaveChanges() > 0)
                {
                    return commentaire;
                }
            }

            return null;
        }
    }
}
