using Microsoft.EntityFrameworkCore;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.CategorieForAdmin;
using NamaShow.DataLayer.Context;
using NamaShow.DataLayer.Entities.Categorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services
{
    public class CategorieService : ICategorieService
    {
        private NamaShowContext _db;
        public CategorieService(NamaShowContext db)
        {
            _db = db;
        }

        public void AddCategorie(CreateCategorieForAdmin categorie)
        {

            _db.Add(new Categorie
            {
                ParentId = categorie.ParentId,
                Title = categorie.Title,
            }
            );
            _db.SaveChanges();
        }

        public void DeleteCategorie(int id)
        {
            var cat = GetCategorieById(id);
            cat.IsDelete = true;
            UpdateCategorie(cat);
        }

        public Categorie GetCategorieById(int id)
        {
            return _db.Categories.Find(id);
        }

        public bool IsExistCategorie(int id)
        {
            return _db.Categories.Any(c => c.CategorieId == id);
        }

        public List<Categorie> ListOfCategorie()
        {
            return _db.Categories.ToList();
        }

        public List<IndexCategorieForAdmin> ListOfCategorieForAdmin()
        {
            return (_db.Categories.Select(c => new IndexCategorieForAdmin
            {
                Id = c.CategorieId,
                Title = c.Title,
                ParentId = c.ParentId

            }).ToList());

        }

        public List<Categorie> NodesOfCategorie(int parentId)
        {
            return _db.Categories.Where(c => c.CategorieId == parentId).Include(c => c.ParentId == parentId).ToList();
        }

        public void UpdateCategorie(Categorie categorie)
        {
            _db.Categories.Update(categorie);
            _db.SaveChanges();
        }
    }
}
