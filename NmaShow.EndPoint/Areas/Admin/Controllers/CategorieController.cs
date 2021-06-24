using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Memcached;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels.CategorieForAdmin;
using NamaShow.DataLayer.Entities.Categorie;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmaShow.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategorieController : Controller
    {
        private ICategorieService _categorieService;
        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        public IActionResult Index()
        {
            var model = _categorieService.ListOfCategorieForAdmin();

            return View(model);
        }

        #region Create
        [HttpGet]
        public IActionResult Create(int? id)
        {
            CreateCategorieForAdmin model = new CreateCategorieForAdmin();
            Categorie parent = new Categorie();

            if (id != null)
            {
                parent = _categorieService.GetCategorieById((int)id);
                if (parent != null)
                {
                    model.ParentId = parent.CategorieId;
                    return View(model);
                }
                ViewBag.msg = "there is no related parent categorie";
                return View();
            }

            return View();

        }
        [HttpPost]
        public IActionResult Create(CreateCategorieForAdmin model)
        {
            if (!ModelState.IsValid)
                return View();

            _categorieService.AddCategorie(model);
            return Redirect("Categorie/Index");
        }

        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Categorie cat = new Categorie();
                cat = _categorieService.GetCategorieById((int)id);
                if (cat != null)
                {
                    EditCategorieForAdmin model = new EditCategorieForAdmin()
                    {
                        Id = cat.CategorieId,
                        ParentId = cat.ParentId,
                        Title = cat.Title,
                    };
                    return View(model);

                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(EditCategorieForAdmin model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Categorie categorie = new Categorie()
            {
                Title = model.Title,
                ParentId = model.ParentId,
                CategorieId = model.Id,
            };

            _categorieService.UpdateCategorie(categorie);
            return Redirect("Categoroie/Index");
        }


        #endregion

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                if (_categorieService.IsExistCategorie((int)id))
                {
                    _categorieService.DeleteCategorie((int)id);
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return Redirect(Request.Headers["Referer"].ToString());

        }

    }
}