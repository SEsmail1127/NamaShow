using Microsoft.AspNetCore.Mvc;
using NamaShow.Core.Services.InterFaces;
using NamaShow.Core.VeiwModels;
using NamaShow.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator;
using NamaShow.Core.Security;
using NamaShow.Core.Convertors;
using TopLearn.Core.Senders;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace NmaShow.EndPoint.Controllers
{
    public class LandingController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _RenderService;
        private IMovieService _movieService;
        private ICategorieService _CategorieService;
        private ISlideService _SlideService;
        private IComeingSoonService _ComeingSoonService;
        public LandingController(IUserService userService, IViewRenderService RenderService
            , IMovieService movieService, ICategorieService CategorieService,
            ISlideService SlideService,IComeingSoonService ComeingSoonService)
        {
            _ComeingSoonService = ComeingSoonService;
            _SlideService = SlideService;
            _CategorieService = CategorieService;
            _userService = userService;
            _RenderService = RenderService;
            _movieService = movieService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var model = new NamaShow.Core.VeiwModels.Landing.HomePageVM();
            ViewBag.categories = _CategorieService.ListOfCategorie();
            model.MovieList = _movieService.ListOfMovieForLanding(1);
            model.Slides = _SlideService.ListOfSlideForLanding();
            model.comeingSoons=_ComeingSoonService.ListOfComeingSoonForLanding();

            return View();
        }
        [Route("MovieList")]
        public IActionResult MovieList(int page = 1)
        {
            ViewBag.Categories = _CategorieService.ListOfCategorie();
            var model = _movieService.ListOfMovieForLanding(page);
            foreach (var item in model)
            {
                item.MovieId = PasswordHelper.EncodePasswordToBase64(item.MovieId.ToString());
            }
            return View(model);

        }

        [Route("MovieDetail")]
        public IActionResult MovieDetail(string id)
        {
            if (id != null)
            {
                var Id = int.Parse(PasswordHelper.DecodeFrom64(id));
                if (_movieService.IsExisteMovieById(Id))
                {
                    var model = _movieService.GetFullDataOfMovieById(Id);
                    return View(model);
                }
            }
            return View("Error_404_Panel");
        }


        #region SignUp
        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp() => View();
        [Route("SignUp")]
        [HttpPost]
        public IActionResult SignUp(SignUpVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_userService.IsExistEmail(model.Email))
            {
                ModelState.AddModelError("Email", "the Email is Not Valid");
                return View(model);
            }
            if (_userService.IsExistUsername(model.Username))
            {
                ModelState.AddModelError("UserName", "the Username is not valid");
                return View(model);
            }
            User user = new User
            {
                Username = model.Username,
                Email = FixedText.FixEmail(model.Email),
                Password = PasswordHelper.EncodePasswordMd5(model.Password),
                IsActive = false,
                RegisterDate = DateTime.Now,
                ActiveCode = NameGenerator.GenerateUniqCode(),
            };

            _userService.AddUser(user);

            string body = _RenderService.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی", body);
            return View("SuccessRegister", user);
        }
        #endregion

        #region LogIn    
        [Route("LogIn")]
        [HttpGet]
        public IActionResult LogIn() => View();
        [Route("LogIn")]
        [HttpPost]
        public IActionResult LogIn(LogInVM logInVM)
        {
            if (!ModelState.IsValid)
                return View();
            User model = null;
            var pass = PasswordHelper.EncodePasswordToBase64(logInVM.Password);
            if (_userService.IsExistEmail(logInVM.Username))
            {
                model = _userService.LogInWithEmail(logInVM.Username, pass);
            }
            else if (_userService.IsExistUsername(logInVM.Username))
            {
                model = _userService.LogInWithUsername(logInVM.Username, pass);
            }
            else
            {
                ModelState.AddModelError("Username", "Username or Password not valid");
                return View();
            }


            if (model != null)
            {
                if (model.IsActive)
                {

                    var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,model.UserId.ToString()),
                new Claim(ClaimTypes.Name,model.Username),
                new Claim(ClaimTypes.Email,model.Email),


            };
                    var Identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(Identity);
                    var prop = new AuthenticationProperties
                    {
                        IsPersistent = logInVM.RemeberMe,

                    };
                    HttpContext.SignInAsync(principal, prop);


                    return View("SignUp");
                }
                ModelState.AddModelError("Username", "your account is not active");
                return View();
            }
            ModelState.AddModelError("Username", "Username or Password not valid");
            return View();

        }
        #endregion

        #region LogOut
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        #endregion

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiveAccount(id);
            return View();
        }

        [Route("ForgotPassword")]
        [HttpGet]
        public IActionResult ForgotPassword() => View();

        [Route("ForgotPassword")]
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordVM model)
        {
            if (!ModelState.IsValid)
                return View();

            if (_userService.IsExistEmail(model.Email))
            {
                var user = _userService.GetUserByEmail(FixedText.FixEmail(model.Email));

                string body = _RenderService.RenderToStringAsync("_ForgotPassword", user);
                SendEmail.Send(user.Email, "forgotpassword", body);
                return View("ResetPassword");
            }
            else
            {
                ModelState.AddModelError("Email", "Email is not valid");
                return View();
            }
        }
        [HttpGet]
        public IActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordVM
            {
                ActiveCode = id,
            });
        }
        [HttpPost]
        public IActionResult ResetPassword(string id, ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userService.GetUserByActiveCode(id);
            if (user != null)
            {
                var pass = PasswordHelper.EncodePasswordMd5(model.Password);
                user.Password = pass;
                _userService.UpdateUser(user);
                return Redirect("/LogIn");
            }

            return NotFound();

        }




    }
}
