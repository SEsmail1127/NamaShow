using Microsoft.EntityFrameworkCore;
using NamaShow.Core.Security;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.Slider;
using NamaShow.DataLayer.Context;
using NamaShow.DataLayer.Entities.Landing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services
{
    public class SlideService : ISlideService
    {
        private NamaShowContext _db;
        public SlideService(NamaShowContext db)
        {
            _db = db;
        }

        public void AddSlideForAdmin(CreateSliderForAdmin model)
        {
            _db.Add(new Slide
            {
                Order = model.Order,
                MovieId = int.Parse(PasswordHelper.DecodeFrom64(model.MovieId)),
                Show = model.Show,
                Url = model.Url,

            });
            _db.SaveChanges();
        }

        public void DeletSlide(string id)
        {
            var model = _db.Slides.Find(int.Parse(PasswordHelper.DecodeFrom64(id)));
            _db.Slides.Remove(model);
            _db.SaveChanges();
        }

        public void EditSlideForAdmin(EditSliderForAdmin model)
        {
            _db.Slides.Update(new Slide
            {
                SlideId = int.Parse(PasswordHelper.DecodeFrom64(model.SlideId)),
                Order = model.Order,
                MovieId = int.Parse(PasswordHelper.DecodeFrom64(model.MovieId)),
                Show = model.Show,
                Url = model.Url,
            });
            _db.SaveChanges();
        }

        public EditSliderForAdmin GetSlideForEditById(string id)
        {
            return (_db.Slides.Select(c => new EditSliderForAdmin
            {
                MovieId = PasswordHelper.EncodePasswordToBase64(c.MovieId.ToString()),
                Order = c.Order,
                Show = c.Show,
                Url = c.Url,
                SlideId = PasswordHelper.EncodePasswordToBase64(c.SlideId.ToString())
            }).SingleOrDefault());
        }

        public List<IndexSliderForAdmin> IndexOfSliderForAdmin()
        {
            return (_db.Slides.OrderByDescending(c => c.SlideId)
             .Include(c => c.Movie).Select(c => new IndexSliderForAdmin
            {
                SlideId = PasswordHelper.EncodePasswordToBase64(c.SlideId.ToString()),
                MovieId = PasswordHelper.EncodePasswordToBase64(c.MovieId.ToString()),
                Order = c.Order,
                Show = c.Show,
                Picture = c.Movie.MoviePicture,
            }).ToList());
        }

        public bool IsExisteSlide(string id)
        {
            return (_db.Slides.Any(c => c.SlideId == int.Parse(PasswordHelper.DecodeFrom64(id))));
        }

        public List<SliderForLandingVM> ListOfSlideForLanding()
        {
            return (_db.Slides.Where(c=>c.Show).OrderByDescending(c => c.SlideId)
                .OrderBy(c => c.Order).Include(c => c.Movie).Take(6)
                .Select(c => new SliderForLandingVM
                {
                    Imdb = c.Movie.Imdb,
                    Time = c.Movie.Time,
                    MovieId = PasswordHelper.EncodePasswordToBase64(c.MovieId.ToString()),
                    Picture = c.Movie.MoviePicture,
                    Title = c.Movie.Title,

                }).ToList());
        }


    }
}
