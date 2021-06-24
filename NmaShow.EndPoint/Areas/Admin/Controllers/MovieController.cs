using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Convertors;
using NamaShow.Core.Security;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.MovieForAdminVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    //  [RoleChecker(1)]
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        public MovieController(IMovieService movieService)
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
                        var collection = _movieService.IndexCollectionForAdmin(int.Parse(Id));
                        foreach (var item in collection)
                        {
                            item.MovieId = PasswordHelper.EncodePasswordToBase64(item.MovieId);
                        }
                        ViewBag.MovieId = id;
                        return View(collection);
                    }
                }
            }
            var model = _movieService.IndexOfMovieForAdmin(page);
            foreach (var item in model)
            {
                item.MovieId = PasswordHelper.EncodePasswordToBase64(item.MovieId);
            }
            return View(model);
        }
        public IActionResult Create(string id)
        {
            if (id != null)
            {

                if (_movieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64( id))))
                {
                    CreateMovieByAdmin model = new CreateMovieByAdmin()
                    {
                        ParentId = id,
                    };
                    return View(model);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMovieByAdmin model, List<int> catMovie)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_movieService.IsExistMovie(model.Title))
            {
                ModelState.AddModelError("Title", "this title is already existe in another movie");
                return View(model);
            }

            if (catMovie.Count == 0)
            {
                ModelState.AddModelError("Trailer", "you have to select at least one categorie");
                return View(model);
            }
            model.Show = true;
            if (model.ParentId != null)
            {
                if (!_movieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64 (model.ParentId))))
                {
                    return View("Error_404_Panel");
                }
                model.ParentId = PasswordHelper.DecodeFrom64(model.ParentId);
            }
            
            var id = _movieService.AddMovieByAdmin(model);
            _movieService.AddCategorieForMovie(id, catMovie);

            return Redirect("Movie/Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                if (_movieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64(id)))) {
                    var model = _movieService.GetMovieForEditByAdmin(int.Parse(PasswordHelper.DecodeFrom64(id)));
                    model.MovieId = PasswordHelper.EncodePasswordToBase64(model.MovieId);
                    return View(model);
                }
            }
            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult Edit(EditMovieByAdmin model, List<int> catMovies)
        {                    
            if (!ModelState.IsValid)
                return View(model);

            if (catMovies.Count == 0)
            {
                ModelState.AddModelError("Trailer", "you have to select at least one categorie");
                return View(model);
            }

            var x = PasswordHelper.DecodeFrom64(model.MovieId);

            if (_movieService.IsExisteMovieById(int.Parse(x)))
            {
                model.MovieId = PasswordHelper.DecodeFrom64(model.MovieId);
                var id = _movieService.UpdateMovieByAdmin(model);
                _movieService.updateCategorieForMovie(id, catMovies);
                return Redirect("Index");
            }
            return View("Error_404_Panel");
        }
        public IActionResult Delete(string id)
        {if (!string.IsNullOrEmpty(id))
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                if (_movieService.IsExisteMovieById(Id))
                {
                    _movieService.DeleteMovie(Id);
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            return View("Error_404_Panel");
        }
    }
}
