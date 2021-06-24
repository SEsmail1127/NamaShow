using NamaShow.Core.VeiwModels.CategorieForAdmin;
using NamaShow.DataLayer.Entities.Categorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services.InterFaces
{
   public interface ICategorieService
    {
        void AddCategorie(CreateCategorieForAdmin categorie);
        void UpdateCategorie(Categorie categorie);
        Categorie GetCategorieById(int id);
        void DeleteCategorie(int id);
        List<Categorie> ListOfCategorie();
        List<Categorie> NodesOfCategorie(int parentId);
        bool IsExistCategorie(int id);
        List<IndexCategorieForAdmin> ListOfCategorieForAdmin();
       
    }
}
