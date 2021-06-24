using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Security;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.Movie.Session.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EpisodeController : Controller
    {
        private IMovieService _movieService;
        public EpisodeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index(string id)
        {
            if (id != null)
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                if (_movieService.IsExisteSessionById(Id))
                {
                    var model = _movieService.IndexEpisodeForAdmin(Id);
                    foreach (var item in model)
                    {
                        item.SeasonId = id;
                        item.EpisodeId = PasswordHelper.EncodePasswordToBase64(item.EpisodeId);
                    }
                    ViewBag.sessionId = id;
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }
        public IActionResult Create(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (_movieService.IsExisteSessionById(int.Parse(PasswordHelper.DecodeFrom64(id))))
                {
                    CreateEpisodeForAdmin model = new CreateEpisodeForAdmin
                    {
                        SeasonId = id,
                    };
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }
        [HttpPost]
        public IActionResult Create(CreateEpisodeForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!string.IsNullOrWhiteSpace(model.SeasonId))
            {
                if (_movieService.IsExisteSessionById(int.Parse(PasswordHelper.DecodeFrom64(model.SeasonId))))
                {
                    var x = model.SeasonId;
                    model.SeasonId = PasswordHelper.DecodeFrom64(model.SeasonId);
                    _movieService.CreateEpisodeForAdmin(model);
                    return Redirect("Episode/Index?id=" + x);
                }
            }

            return View("Error_404_Panel");
        }
        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                if (_movieService.IsExisteEpisodeById(Id))
                {
                    var model = _movieService.GetEpisodeForEdit(Id);
                    return View(new EditEpisodeForAdmin
                    {
                        EpisodeId = PasswordHelper.EncodePasswordToBase64(model.EpisodeId),
                        SeasonId = PasswordHelper.EncodePasswordToBase64(model.SeasonId),
                        EpisodeNumber = model.EpisodeNumber,
                        Show = model.Show,
                    });
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(EditEpisodeForAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.EpisodeId != null)
            {
                var x = model.SeasonId;
                model.EpisodeId = PasswordHelper.DecodeFrom64(model.EpisodeId);
                model.SeasonId = PasswordHelper.DecodeFrom64(model.SeasonId);

                if (_movieService.IsExisteEpisodeById(int.Parse(model.EpisodeId)))
                {
                    _movieService.EditEpisodeForAdmin(model);
                    return Redirect("Episode/Index?id=" + x);
                }
            }
            return View("Error_404_Panel");
        }
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                if (_movieService.IsExisteEpisodeById(Id))
                {
                    _movieService.DeleteEpisode(Id);
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            return View("Error_404_Panel");
        }

    }
}
