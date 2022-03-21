using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP06.Classes;

namespace TP06.Datas
{
    internal class UtilisateurRepository : BaseRepository, IRepository<Utilisateur>
    {
        public Utilisateur Add(Utilisateur entity)
        {
            _context.Utilisateurs.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return entity;
            }

            return null;
        }

        public bool Delete(int id)
        {
            Utilisateur utilisateur = Get(id);

            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public Utilisateur Get(int id)
        {
            return _context.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == id);
        }

        public List<Utilisateur> GetAll()
        {
            return _context.Utilisateurs.ToList();
        }

        public Utilisateur Update(int id, Utilisateur entity)
        {
            Utilisateur utilisateur = Get(id);

            if (utilisateur != null)
            {
                utilisateur.Prenom = entity.Prenom;
                utilisateur.Nom = entity.Nom;
                utilisateur.Telephone = entity.Telephone;
                utilisateur.Email = entity.Email;

                _context.Utilisateurs.Update(utilisateur);

                if (_context.SaveChanges() > 0)
                {
                    return utilisateur;
                }
            }

            return null;
        }

        public Utilisateur AddOrUpdate(Utilisateur entity)
        {
            if (entity.Id == 0) return Add(entity);
            else return Update(entity.Id, entity);
        }
    }
}
