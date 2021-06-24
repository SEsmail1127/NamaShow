using NamaShow.DataLayer.Entities.Categorie;
using NamaShow.DataLayer.Entities.Landing;
using NamaShow.DataLayer.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.Landing
{
    public class MovieListForLanding
    {
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string MoviePicture { get; set; }
        public MovieType MovieType { get; set; }
        public DateTime? releaseTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Rate> Rates { get; set; }
        public List<CatMovie> CatMovies { get; set; }
        public float? Imdb { get; set; }
        public int? Time { get; set; }
        public string Describe { get; set; }
    }
    public class MovieDetailViewModel
    {

    }
    public class HomePageVM
    {
        public List<Slider.SliderForLandingVM> Slides { get; set; }
        public List<MovieListForLanding> MovieList { get; set; }
        public List<ComeingSoon.ComeingSoonForLandingVM> comeingSoons { get; set; }
    }





}
