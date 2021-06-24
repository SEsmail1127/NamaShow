using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamaShow.DataLayer.Entities.Movie;
using NamaShow.Core.VeiwModels.Movie.Session;
using NamaShow.Core.Security;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionController : Controller
    {
        private IMovieService _movieService;
        public SessionController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index(string id, int page = 1)
        {
            if (id != null)
            {
                var Id = PasswordHelper.DecodeFrom64(id);
                if (Id != "0")
                {
                    if (_movieService.IsExisteMovieById(int.Parse(Id)))
                    {
                        var model = _movieService.IndexOfSessionForAdmin(int.Parse(Id));
                        ViewBag.MovieId = id;
                        foreach (var item in model)
                        {
                            item.SeasonId = PasswordHelper.EncodePasswordToBase64(item.SeasonId);
                            item.MovieId = id;
                        }
                        return View(model);
                    }
                }
            }
            return View("Error_404_Panel");
        }
        public IActionResult Create(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string Id = PasswordHelper.DecodeFrom64(id);
                if (_movieService.IsExisteMovieById(int.Parse(Id)))
                {
                    CreateSessionForAdmin model = new CreateSessionForAdmin
                    {
                        MovieId = id,
                    };
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Create(CreateSessionForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.MovieId != null)
            {
                var x = model.MovieId;
                model.MovieId = PasswordHelper.DecodeFrom64(model.MovieId);
                if (_movieService.IsExisteMovieById(int.Parse(model.MovieId)))
                {
                    _movieService.AddSeason(model);
                    return Redirect("Session/Index?id=" + x);
                }
            }
            return View("Error_404_Panel");
        }
        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var Id = PasswordHelper.DecodeFrom64(id);
                if (_movieService.IsExisteSessionById(int.Parse(Id)))
                {
                    var model = _movieService.GetSeasonById(int.Parse(Id));
                    if (model != null)
                    {
                        return View(new EditSessionForAdmin
                        {
                            MovieId = PasswordHelper.EncodePasswordToBase64(model.MovieId.ToString()),
                            SeasonId = id,
                            SeasonNumber = model.SeasonNumber,
                            Show = model.Show,
                        });
                    }
                }
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Edit(EditSessionForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.UpdateSeason(new Season
            {
                MovieId = int.Parse(PasswordHelper.DecodeFrom64(model.MovieId)),
                Show = model.Show,
                SeasonNumber = model.SeasonNumber,
                SeasonId = int.Parse(PasswordHelper.DecodeFrom64(model.SeasonId)),

            });
            return Redirect("Index?id=" + model.MovieId);
        }
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                   
                    if (_movieService.IsExisteSessionById(Id))
                    {
                        _movieService.DeleteSeason(Id);
                        return Redirect(Request.Headers["Referer"].ToString());
                    }             
            }
            return NotFound();
        }

    }
}
