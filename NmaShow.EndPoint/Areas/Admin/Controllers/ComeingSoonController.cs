using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamaShow.Core.VeiwModels.ComeingSoonVM;
using NamaShow.Core.Security;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComeingSoonController : Controller
    {


        private IMovieService _MovieService;
        private IComeingSoonService _ComeingSoonService;
        public ComeingSoonController(IMovieService movieService, IComeingSoonService comeingSoonService)
        {
            _ComeingSoonService = comeingSoonService;
            _MovieService = movieService;
        }
        public IActionResult Index()
        {
            var model = _ComeingSoonService.IndexOfComeingSoonrForAdmin();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateComeingSoon model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
                return View(model);
            }
            if (_MovieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64(model.MovieId))))
            {

                _ComeingSoonService.AddComeingSoonForAdmin(model);
                return Redirect("ComeingSoon/Index");
            }


            return View("Error_404_Panel");
        }
        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                if (_ComeingSoonService.IsExisteComeingSoon(id))
                {
                    var model = _ComeingSoonService.GetComeingSoonForEditById(id);
                    ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Edit(EditComeingSoon model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Movies = _MovieService.ListOfMovieForCreateingSlide();
                return View(model);
            }
            if (model.ComeingSoonId != null && model.MovieId != null)
            {
                if (_ComeingSoonService.IsExisteComeingSoon(model.ComeingSoonId) && _MovieService.IsExisteMovieById(int.Parse(PasswordHelper.DecodeFrom64(model.MovieId))))
                {
                    _ComeingSoonService.EditComeingSoonForAdmin(model);
                    return Redirect("Index");
                }
            }

            return View("Error_404_Panel");
        }

        public IActionResult Delete(string id)
        {
            if (_ComeingSoonService.IsExisteComeingSoon(id))
            {
                _ComeingSoonService.DeletComeingSoon(id);
                return Redirect("Index");
            }
            return View("Error_404_Panel");
        }
    }

}

