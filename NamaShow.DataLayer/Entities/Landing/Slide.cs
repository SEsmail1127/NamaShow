using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.DataLayer.Entities.Landing
{
    public class Slide
    {
        [Key]
        public int SlideId { get; set; }
        public bool Show { get; set; }
        [Required]
        public string Url { get; set; }
        public byte Order { get; set; }
        [Required]
        public int MovieId { get; set; }

        #region Relation
        public virtual Movie.Movie Movie { get; set; }
        #endregion

    }
}
