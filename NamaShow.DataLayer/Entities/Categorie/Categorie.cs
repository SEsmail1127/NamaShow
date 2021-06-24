using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamaShow.DataLayer.Entities.Movie;

namespace NamaShow.DataLayer.Entities.Categorie
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }

        [Required(ErrorMessage ="please fill in title")]
        public String Title { get; set; }
        public int? ParentId { get; set; }
        public bool IsDelete { get; set; }
        #region Relation
        [ForeignKey("ParentId")]
        public virtual List<Categorie> ParentCategories { get; set; }
        public virtual List<NamaShow.DataLayer.Entities.Movie.CatMovie> CatMovies { get; set; }

        #endregion
    }
}
