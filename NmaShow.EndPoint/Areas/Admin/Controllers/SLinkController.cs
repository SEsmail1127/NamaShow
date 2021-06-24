using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Security;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.Movie.Session.Episode.SLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SLinkController : Controller
    {
        private IMovieService _movieService;
        public SLinkController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index(string id)
        {
            if (id != null)
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                if (_movieService.IsExisteEpisodeById(Id))
                {
                    var model = _movieService.IndexSerialLinkForAdmin(Id);
                    ViewBag.Episode = id;
                    foreach (var item in model)
                    {
                        item.LinkId = PasswordHelper.EncodePasswordToBase64(item.LinkId);
                        item.EpisodeId = id;
                    }
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }
        public IActionResult Create(string id)
        {
            var Id = int.Parse(PasswordHelper.DecodeFrom64(id));

            if (_movieService.IsExisteEpisodeById(Id))
            {
                CreateSLinkForAdmin model = new CreateSLinkForAdmin()
                {
                    EpisodeId = id,
                };
                return View(model);
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Create(CreateSLinkForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.EpisodeId != null)
            {
                var x = model.EpisodeId;
                model.EpisodeId = PasswordHelper.DecodeFrom64(model.EpisodeId);
                if (_movieService.IsExisteEpisodeById(int.Parse(model.EpisodeId)))
                {
                    _movieService.CreateSerialLinkForAdmin(model);
                    return Redirect("SLink/Index?id=" + x);
                }
            }
            return View("Error_404_Panel");
        }
        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var Id = PasswordHelper.DecodeFrom64(id);
                if (_movieService.IsExisteLinkById(int.Parse(Id)))
                {
                    var model = _movieService.GetSerialLinkForEdit(int.Parse(Id));
                    if (model != null)
                    {
                        model.LinkId = id;
                        model.EpisodeId = PasswordHelper.EncodePasswordToBase64(model.EpisodeId);
                        return View(model);
                    }
                }
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Edit(EditSLinkForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var x = model.EpisodeId;
            if (_movieService.IsExisteLinkById(int.Parse(PasswordHelper.DecodeFrom64(model.LinkId))))
            {
                model.EpisodeId = PasswordHelper.DecodeFrom64(model.EpisodeId);
                model.LinkId = PasswordHelper.DecodeFrom64(model.LinkId);

                _movieService.EditSerialLinkForAdmin(model);
                return Redirect("Index?id=" + x);
            }
            return View("Error_404_Panel");
        }
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                _movieService.DeleteLink(int.Parse(PasswordHelper.DecodeFrom64( id)));
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View("Error_404_Panel");
        }

    }
}
