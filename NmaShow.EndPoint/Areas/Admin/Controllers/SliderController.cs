using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Security;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private IMovieService _MovieService;
        private ISlideService _SlideService;
        public SliderController(IMovieService movieService, ISlideService slideService)
        {
            _SlideService = slideService;
            _MovieService = movieService;
        }
        public IActionResult Index()
        {
            var model = _SlideService.IndexOfSliderForAdmin();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSliderForAdmin model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
                return View(model);
            }
            if (_MovieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64(model.MovieId))))
            {

                _SlideService.AddSlideForAdmin(model);
                return Redirect("Slider/Index");
            }


            return View("Error_404_Panel");
        }
        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                if (_SlideService.IsExisteSlide(id))
                {
                    var model = _SlideService.GetSlideForEditById(id);
                    ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Edit(EditSliderForAdmin model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
                return View(model);
            }
            if (model.SlideId != null && model.MovieId != null)
            {
                if (_SlideService.IsExisteSlide(model.SlideId) && _MovieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64(model.MovieId))))
                {
                    _SlideService.EditSlideForAdmin(model);
                    return Redirect("Index");
                }
            }

            return View("Error_404_Panel");
        }

        public IActionResult Delete(string id)
        {
            if (_SlideService.IsExisteSlide(id))
            {
                _SlideService.DeletSlide(id);
                return Redirect("Index");
            }
            return View("Error_404_Panel");
        }
    }
}
