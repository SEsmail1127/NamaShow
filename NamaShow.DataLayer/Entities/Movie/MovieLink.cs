using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.DataLayer.Entities.Movie
{
  public class MovieLink
    {
        public int MovieLinkId { get; set; }
        [Required(ErrorMessage = "please upload movies file")]   
        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
        public int? Price { get; set; }
        public bool Show { get; set; }
        public bool IsDelete { get; set; }
        public int? MovieId { get; set; }

        #region Relation
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
        #endregion

    }
}
