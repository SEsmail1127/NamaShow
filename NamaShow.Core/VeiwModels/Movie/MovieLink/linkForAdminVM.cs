using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.Movie.MovieLink
{
    public class IndexOfLinkForMovie
    {
        public int Id { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public int? MovieId { get; set; }
        public bool Show { get; set; }
        public int? Price { get; set; }
    }
    public class CreateMovieLinkForAdmin
    {
       
        [Required(ErrorMessage = "please upload movies file")]
        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
        public int? Price { get; set; }
        public int? MovieId { get; set; }
    }
    public class EditMovieLinkForAdmin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please upload movies file")]
        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
        public int? Price { get; set; }
        public int? MovieId { get; set; }
        public bool Show { get; set; }
    }
}
