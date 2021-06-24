using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.Movie.MovieLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LinkController : Controller
    {
        private IMovieService _movieService;
        public LinkController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index(int? id,int page=1)
        {
            if (id != null)
            {
                var model = _movieService.GetLinkesOfMovieForAdmin((int)id,page);
                ViewBag.MovieId = id;
                return View(model);
            }
            return NotFound();
        }
        public IActionResult Create(int? id)
        {
            CreateMovieLinkForAdmin model = new CreateMovieLinkForAdmin()
            {
                MovieId = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateMovieLinkForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.AddMovieLinkByAdmin(model);
            return Redirect("Index?id=" + model.MovieId);
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var model = _movieService.GetMovieLinkForAdminById((int)id);
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(EditMovieLinkForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _movieService.EditMovieLinkForAdmin(model);
            return Redirect("Index?id=" + model.MovieId);
        }
        public IActionResult Delete(int? id)
        {
            if(id!=null)
            {
                _movieService.DeleteMovieLink((int)id);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return NotFound();
        }
  
    }
}
