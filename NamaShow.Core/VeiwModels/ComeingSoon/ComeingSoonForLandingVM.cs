using NamaShow.DataLayer.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.ComeingSoon
{
  public  class ComeingSoonForLandingVM
    {
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Describe { get; set; }
        public string Picture { get; set; }
        public int? Time { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<CatMovie> CatMovies { get; set; }
    }
}
