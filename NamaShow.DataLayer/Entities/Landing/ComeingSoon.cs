using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.DataLayer.Entities.Landing
{
    public class ComeingSoon
    {
        [Key]
        public int ComeingSoonId { get; set; }
        [Required]
        public int? MovieId { get; set; }
        [Required]
        public string Url { get; set; }
        public bool Show { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie.Movie Movie { get; set; }
    }
}
