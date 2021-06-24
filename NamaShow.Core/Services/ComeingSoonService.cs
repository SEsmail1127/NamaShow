using Microsoft.EntityFrameworkCore;
using NamaShow.Core.Security;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.ComeingSoon;
using NamaShow.Core.VeiwModels.ComeingSoonVM;
using NamaShow.DataLayer.Context;
using NamaShow.DataLayer.Entities.Landing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services
{
    public class ComeingSoonService : IComeingSoonService
    {
        private NamaShowContext _db;
        public ComeingSoonService(NamaShowContext db)
        {
            _db = db;
        }
        public void AddComeingSoonForAdmin(CreateComeingSoon model)
        {
            _db.ComeingSoons.Add(new ComeingSoon
            {
                MovieId = int.Parse(PasswordHelper.DecodeFrom64(model.MovieId.ToString())),
                Show = model.Show,
                Url = model.Url,
            });
            _db.SaveChanges();
        }

        public void DeletComeingSoon(string id)
        {
            var model = _db.ComeingSoons.Find(int.Parse(PasswordHelper.DecodeFrom64(id.ToString())));
            _db.ComeingSoons.Remove(model);
            _db.SaveChanges();
        }

        public void EditComeingSoonForAdmin(EditComeingSoon model)
        {
            _db.ComeingSoons.Update(new ComeingSoon
            {
                MovieId = int.Parse(PasswordHelper.DecodeFrom64(model.MovieId.ToString())),
                ComeingSoonId = int.Parse(PasswordHelper.DecodeFrom64(model.ComeingSoonId.ToString())),
                Show = model.Show,
                Url = model.Url,
            });
        }

        public EditComeingSoon GetComeingSoonForEditById(string id)
        {
            return (_db.ComeingSoons
                .Where(c => c.ComeingSoonId == int.Parse(PasswordHelper.DecodeFrom64(id)))
                .Select(c => new EditComeingSoon
                {
                    Url = c.Url,
                    MovieId = PasswordHelper.EncodePasswordToBase64(c.MovieId.ToString()),
                    Show = c.Show,
                    ComeingSoonId = PasswordHelper.EncodePasswordToBase64(c.ComeingSoonId.ToString()),
                })
                .SingleOrDefault());
        }

        public List<IndexComeingSoon> IndexOfComeingSoonrForAdmin()
        {
            return (_db.ComeingSoons.OrderByDescending(c => c.ComeingSoonId)
                .Include(c => c.Movie)
                .Select(c => new IndexComeingSoon
                {
                    ComeingSoonId = PasswordHelper.EncodePasswordToBase64(c.ComeingSoonId.ToString()),
                    MovieId = PasswordHelper.EncodePasswordToBase64(c.MovieId.ToString()),
                    Picture = c.Movie.MoviePicture,
                    Show = c.Show,
                }).ToList());
        }

        public bool IsExisteComeingSoon(string id)
        {
            return (_db.ComeingSoons.Any(c => c.ComeingSoonId == int.Parse(PasswordHelper.DecodeFrom64(id))));
        }

        public List<ComeingSoonForLandingVM> ListOfComeingSoonForLanding()
        {
            return (_db.ComeingSoons.Where(c => c.Show).OrderByDescending(c => c.ComeingSoonId)
                .Include(c => c.Movie).ThenInclude(c => c.CatMovies)
                .Take(6).Select(c => new ComeingSoonForLandingVM
                {
                    MovieId = PasswordHelper.EncodePasswordToBase64(c.MovieId.ToString()),
                    CatMovies = c.Movie.CatMovies,
                    Describe = c.Movie.Describe,
                    ReleaseDate = c.Movie.releaseTime,
                    Title = c.Movie.Title,
                    Time = c.Movie.Time,
                    Picture = c.Movie.MoviePicture,
                }).ToList());
        }
   
    }
}
