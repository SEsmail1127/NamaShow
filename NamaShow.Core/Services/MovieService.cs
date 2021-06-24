using Generator;
using Microsoft.EntityFrameworkCore;
using NamaShow.Core.Security;
using NamaShow.Core.VeiwModels.Landing;
using NamaShow.Core.VeiwModels.Movie.MovieLink;
using NamaShow.Core.VeiwModels.Movie.Session;
using NamaShow.Core.VeiwModels.Movie.Session.Episode;
using NamaShow.Core.VeiwModels.Movie.Session.Episode.SLink;
using NamaShow.Core.VeiwModels.MovieForAdminVM;
using NamaShow.DataLayer.Context;
using NamaShow.DataLayer.Entities.Movie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace NamaShow.Core.Services.InterFaces
{
    public class MovieService : IMovieService
    {
        private NamaShowContext _db;
        public MovieService(NamaShowContext db)
        {
            _db = db;
        }


        public void AddCommentForMovie(Comment comment)
        {
            _db.Add(comment);
            _db.SaveChanges();
        }

        public void AddLinkForMovie(Link link)
        {
            _db.Add(link);
            _db.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            _db.Add(movie);
            _db.SaveChanges();
        }

        public void AddRateForMovie(Rate rate)
        {
            _db.Add(rate);
            _db.SaveChanges();
        }

        public void AddCommentLike(CommentLike commentLike)
        {
            _db.Add(commentLike);
            _db.SaveChanges();
        }

        public void DeleteLink(int id)
        {
            var model = GetLinkById(id);
            model.IsDelete = true;
            UpdateLink(model);
        }

        public void DeleteMovie(int id)
        {
            var model = GetMovieById(id);
            model.IsDelete = true;
            UpdateMovie(model);
        }

        public void EditComment(Comment comment)
        {
            _db.Comments.Update(comment);
            _db.SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            return _db.Comments.Find(id);
        }

        public List<Comment> GetCommentsOfMovie(int MovieId)
        {
            return _db.Comments.Where(c => c.MovieId == MovieId).ToList();
        }

        public Movie GetFullDataOfMovieById(int id)
        {

            return _db.Movies.Where(c => c.MovieId == id).Include(c => c.MovieLinks).Include(c => c.Rates).Include(c => c.Comments).ThenInclude(c => c.CommentLikes).SingleOrDefault();
        }

        public List<CommentLike> GetLikesOfComment(int commentId)
        {
            return _db.CommentLikes.Where(c => c.CommentId == commentId).ToList();
        }

        public Link GetLinkById(int id)
        {
            return _db.Links.Find(id);
        }

        public List<MovieLink> GetLinkesOfMovie(int MovieId)
        {
            return _db.MovieLinks.Where(c => c.MovieId == MovieId).ToList();
        }

        public List<Movie> GetListOfMovie(int page)
        {
            return _db.Movies.OrderByDescending(c => c.MovieId).Skip(page * 10).Take(10).ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.Find(id);
        }

        public Rate GetRateById(int id)
        {
            return _db.Rates.Find(id);
        }

        public List<Rate> GetRatesOfMovie(int MovieId)
        {
            return _db.Rates.Where(c => c.MovieId == MovieId).ToList();
        }

        public void ReadedComment(int id)
        {
            var model = GetCommentById(id);
            model.Readed = true;
            _db.Update(model);
            _db.SaveChanges();
        }

        public void ShowComment(int id)
        {
            var model = GetCommentById(id);
            if (model.Show == false)
                model.Show = true;
            else
                model.Show = false;
            _db.Update(model);
            _db.SaveChanges();
        }

        public void ToggleShowlLink(int id)
        {
            var model = GetLinkById(id);
            if (model.Show == false)
                model.Show = true;
            else
                model.Show = false;
            _db.Update(model);
            _db.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            _db.Comments.Update(comment);
            _db.SaveChanges();
        }

        public void UpdateLink(Link link)
        {
            _db.Links.Update(link);
            _db.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
        }

        public void UpdateRateOfMOvie(Rate rate)
        {
            _db.Update(rate);
            _db.SaveChanges();
        }

        public void AddSeason(CreateSessionForAdmin season)
        {
            Season model = new Season()
            {
                MovieId = int.Parse(season.MovieId),
                Show = true,
                SeasonNumber = season.SeasonNumber,
            };
            _db.Add(model);
            _db.SaveChanges();
        }

        public void UpdateSeason(Season season)
        {
            _db.Update(season);
            _db.SaveChanges();
        }

        public List<Season> ListOfSeason(int SerialId)
        {
            throw new NotImplementedException();
        }

        public Season GetFullDataOfSeason(int id)
        {
            throw new NotImplementedException();
        }

        public void ShowSeason(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSeason(int id)
        {
            var model = GetSeasonById(id);
            model.IsDelete = true;
            UpdateSeason(model);
        }

        public Season GetSeasonById(int id)
        {
            return _db.Seasons.Find(id);
        }

        public bool IsExistMovie(string title)
        {
            return _db.Movies.Any(c => c.Title == title);
        }

        public int AddMovieByAdmin(CreateMovieByAdmin model)
        {
            Movie movie = new Movie()
            {
                Actors = model.Actors,
                country = model.country,
                Describe = model.Describe,
                Director = model.Director,
                EndTime = model.EndTime,
                releaseTime = model.releaseTime,
                MovieType = model.MovieType,
                Title = model.Title,
                Show = true,
            };
            if (model.ParentId != null)
                movie.ParentId = int.Parse(model.ParentId);

            if (model.MoviePicture != null)
            {
                string imagePath = "";
                movie.MoviePicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.MoviePicture.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/Row", movie.MoviePicture);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.MoviePicture.CopyTo(stream);
                }
                Convertors.ImageConvertor img = new Convertors.ImageConvertor();

                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/MoviePictureForList", movie.MoviePicture);
                img.Image_resize(imagePath, thumbPath, 100);

                Convertors.ImageConvertor img2 = new Convertors.ImageConvertor();
                string NormalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/NormalMoviePicture", movie.MoviePicture);
                img2.Image_resize(imagePath, NormalPath, 500);

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic/UserAvatarForList", User.UserPicture);

                //if (File.Exists(path))
                //{
                //    File.Delete(path);
                //}
            }

            if (model.Trailer != null)
            {
                string imagePath = "";
                movie.Trailer = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.Trailer.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/movieTrailer", movie.Trailer);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.Trailer.CopyTo(stream);
                }
            }

            AddMovie(movie);

            return movie.MovieId;
        }

        public void AddCategorieForMovie(int MovieId, List<int> CatIds)
        {
            foreach (var item in CatIds)
            {
                _db.CatMovies.Add(new CatMovie
                {
                    CategorieId = item,
                    MovieId = MovieId,
                });

            }
            _db.SaveChanges();
        }

        public List<IndexMovieForAdmin> IndexOfMovieForAdmin(int page)
        {
            var model = _db.Movies.OrderByDescending(c => c.MovieId).Skip((page - 1) * 10).Take(10);

            var x = model.Select(c => new IndexMovieForAdmin()
            {
                MovieId = c.MovieId.ToString(),
                MoviePicture = c.MoviePicture,
                MovieType = c.MovieType,
                releaseTime = c.releaseTime,
                Title = c.Title,
                Show = c.Show,
            }).ToList();

            return (x);
        }

        public void AddMovieLinkByAdmin(CreateMovieLinkForAdmin model)
        {
            _db.MovieLinks.Add(new MovieLink
            {
                MovieId = model.MovieId,
                Show = true,
                LinkName = model.LinkName,
                LinkUrl = model.LinkUrl,
                Price = model.Price,
            });
            _db.SaveChanges();
        }

        public EditMovieLinkForAdmin GetMovieLinkForAdminById(int id)
        {
            var MovieLink = _db.MovieLinks.SingleOrDefault(c => c.MovieId == id);
            return (new EditMovieLinkForAdmin
            {
                Id = MovieLink.MovieLinkId,
                MovieId = MovieLink.MovieId,
                LinkName = MovieLink.LinkName,
                LinkUrl = MovieLink.LinkUrl,
                Price = MovieLink.Price,
                Show = MovieLink.Show,
            });
        }

        public void EditMovieLinkForAdmin(EditMovieLinkForAdmin model)
        {
            MovieLink MovieLink = new MovieLink()
            {
                MovieId = model.MovieId,
                MovieLinkId = model.Id,
                LinkUrl = model.LinkUrl,
                LinkName = model.LinkName,
                Show = model.Show,
                Price = model.Price,

            };
            UpdateMovieLink(MovieLink);
        }

        public void UpdateMovieLink(MovieLink movieLink)
        {
            _db.Update(movieLink);
            _db.SaveChanges();
        }

        public void DeleteMovieLink(int id)
        {
            var model = GetMovieLinkByid(id);
            model.IsDelete = true;
            UpdateMovieLink(model);
        }

        public MovieLink GetMovieLinkByid(int id)
        {
            return _db.MovieLinks.SingleOrDefault(c => c.MovieLinkId == id);
        }

        public List<IndexOfLinkForMovie> GetLinkesOfMovieForAdmin(int id, int page)
        {
            var model = _db.MovieLinks.Where(c => c.MovieId == id).Select(c => new IndexOfLinkForMovie
            {
                Id = c.MovieLinkId,
                Show = c.Show,
                LinkName = c.LinkName,
                Price = c.Price,
                MovieId = c.MovieId,
            }).ToList();
            return (model);
        }

        public List<IndexOfSessionForAdmin> IndexOfSessionForAdmin(int MovieId)
        {
            var model = _db.Seasons.Where(c => c.MovieId == MovieId).OrderByDescending(c => c.SeasonId).Select(c => new IndexOfSessionForAdmin
            {
                MovieId = c.MovieId.ToString(),
                SeasonId = c.SeasonId.ToString(),
                SeasonNumber = c.SeasonNumber,
                Show = c.Show,
            }).ToList();
            return (model);
        }

        public Episode GetEpisodeById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEpisode(Episode episode)
        {
            _db.Update(episode);
            _db.SaveChanges();
        }

        public void AddEpisode(Episode episode)
        {
            _db.Add(episode);
            _db.SaveChanges();
        }

        public List<IndexEpisodeForAdmin> IndexEpisodeForAdmin(int sessionId)
        {
            var model = _db.Episodes.Where(c => c.SeasonId == sessionId).OrderByDescending(c => c.EpisodeId).Select(c => new IndexEpisodeForAdmin
            {
                EpisodeId = c.EpisodeId.ToString(),
                SeasonId = c.SeasonId.ToString(),
                EpisodeNumber = c.EpisodeNumber,
                Show = c.Show,

            }).ToList();
            return model;
        }

        public void CreateEpisodeForAdmin(CreateEpisodeForAdmin model)
        {
            Episode episode = new Episode()
            {
                Show = true,
                PuttingUpDate = DateTime.Now,
                EpisodeNumber = model.EpisodeNumber,
                SeasonId = int.Parse(model.SeasonId),
            };
            AddEpisode(episode);
        }

        public void EditEpisodeForAdmin(EditEpisodeForAdmin model)
        {
            Episode episode = new Episode()
            {
                EpisodeId = int.Parse(model.EpisodeId),
                Show = model.Show,
                SeasonId = int.Parse(model.SeasonId),
                EpisodeNumber = model.EpisodeNumber,

            };
            UpdateEpisode(episode);
        }

        public EditEpisodeForAdmin GetEpisodeForEdit(int id)
        {
            var episode = _db.Episodes.Find(id);
            EditEpisodeForAdmin model = new EditEpisodeForAdmin()
            {
                EpisodeId = episode.EpisodeId.ToString(),
                EpisodeNumber = episode.EpisodeNumber,
                SeasonId = episode.SeasonId.ToString(),
                Show = episode.Show,
            };
            return model;
        }

        public void DeleteEpisode(int id)
        {
            var model = GetEpisodeById(id);
            model.IsDelete = true;
            UpdateEpisode(model);
        }

        public List<IndexSLinkForAdmin> IndexSerialLinkForAdmin(int EpisodeId)
        {
            return (_db.Links.Where(c => c.EpisodeId == EpisodeId)
                .OrderByDescending(c => c.LinkId).Select(c => new IndexSLinkForAdmin()
                {
                    EpisodeId = c.EpisodeId.ToString(),
                    LinkId = c.LinkId.ToString(),
                    LinkName = c.LinkName,
                    Price = c.Price,
                    Show = c.Show,

                }).ToList());
        }

        public void CreateSerialLinkForAdmin(CreateSLinkForAdmin model)
        {
            AddLinkForMovie(new Link()
            {
                Price = model.Price,
                LinkUrl = model.LinkUrl,
                LinkName = model.LinkName,
                EpisodeId = int.Parse(model.EpisodeId),
                Show = true,
            });
        }

        public void EditSerialLinkForAdmin(EditSLinkForAdmin model)
        {
            UpdateLink(new Link()
            {
                EpisodeId = int.Parse(model.EpisodeId),
                LinkId = int.Parse(model.LinkId),
                LinkName = model.LinkName,
                LinkUrl = model.LinkUrl,
                Price = model.Price,
                Show = model.Show,
            });
        }

        public EditSLinkForAdmin GetSerialLinkForEdit(int id)
        {
            var Link = GetLinkById(id);

            if (Link != null)
                return (new EditSLinkForAdmin()
                {
                    EpisodeId = Link.EpisodeId.ToString(),
                    LinkId = Link.LinkId.ToString(),
                    LinkName = Link.LinkName,
                    LinkUrl = Link.LinkUrl,
                    Price = Link.Price,
                    Show = Link.Show,
                });
            return null;

        }

        public List<IndexMovieForAdmin> IndexCollectionForAdmin(int id)
        {
            var collection = _db.Movies.Where(c => c.ParentId == id)
                .OrderByDescending(c => c.MovieId).Select(c => new IndexMovieForAdmin()
                {
                    MovieId = c.MovieId.ToString(),
                    MoviePicture = c.MoviePicture,
                    MovieType = c.MovieType,
                    releaseTime = c.releaseTime,
                    Show = c.Show,
                    Title = c.Title,
                }).ToList();
            return (collection);
        }

        public List<MovieListForLanding> ListOfMovieForLanding(int page)
        {
            var model = _db.Movies.Where(c => c.Show).OrderByDescending(c => c.MovieId)
                .Skip((page - 1) * 10).Take(page).Include(c => c.CatMovies)
                .Select(c => new MovieListForLanding
                {
                    Rates = c.Rates,
                    MovieId = c.MovieId.ToString(),
                    MoviePicture = c.MoviePicture,
                    MovieType = c.MovieType,
                    Title = c.Title,
                    releaseTime = c.releaseTime,
                    EndTime = c.EndTime,
                    CatMovies = c.CatMovies,
                    Describe = c.Describe,
                    Imdb = c.Imdb,
                    Time = c.Time,

                }).ToList();
            return (model);
        }

        public EditMovieByAdmin GetMovieForEditByAdmin(int id)
        {
            var model = _db.Movies.Where(c => c.MovieId == id).Include(c => c.CatMovies).Select(c => new EditMovieByAdmin
            {
                Actors = c.Actors,
                country = c.country,
                Describe = c.Describe,
                Director = c.Director,
                EndTime = c.EndTime,
                MovieId = c.MovieId.ToString(),

                MovieType = c.MovieType,
                releaseTime = c.releaseTime,
                Show = c.Show,
                Title = c.Title,

                CatMovies = c.CatMovies,
            }).SingleOrDefault();
            return model;

        }

        public int UpdateMovieByAdmin(EditMovieByAdmin model)
        {
            Movie movie = GetMovieById(int.Parse(model.MovieId));

            movie.CatMovies = model.CatMovies;
            movie.Actors = model.Actors;
            movie.country = model.country;
            movie.Describe = model.Describe;
            movie.Director = model.Director;
            movie.EndTime = model.EndTime;
            movie.MovieId = int.Parse(model.MovieId);
            movie.Show = model.Show;
            movie.Title = model.Title;


            if (model.MoviePicture != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/Row", movie.MoviePicture);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/MoviePictureForList", movie.MoviePicture);

                if (File.Exists(path1))
                {
                    File.Delete(path1);
                }
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/NormalMoviePicture", movie.MoviePicture);

                if (File.Exists(path2))
                {
                    File.Delete(path2);
                }

                string imagePath = "";
                movie.MoviePicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.MoviePicture.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/Row", movie.MoviePicture);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.MoviePicture.CopyTo(stream);
                }
                Convertors.ImageConvertor img = new Convertors.ImageConvertor();

                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/MoviePictureForList", movie.MoviePicture);
                img.Image_resize(imagePath, thumbPath, 100);

                Convertors.ImageConvertor img2 = new Convertors.ImageConvertor();
                string NormalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/moviePicture/NormalMoviePicture", movie.MoviePicture);
                img2.Image_resize(imagePath, NormalPath, 500);


            }
            if (model.Trailer != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/movieTrailer", movie.Trailer);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                string imagePath = "";
                movie.MoviePicture = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.Trailer.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieFile/movieTrailer", movie.Trailer);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.MoviePicture.CopyTo(stream);
                }
            }

            return movie.MovieId;
        }

        public void updateCategorieForMovie(int MovieId, List<int> CatIds)
        {
            _db.CatMovies.Where(c => c.MovieId == MovieId).ToList().ForEach(c => _db.CatMovies.Remove(c));
            AddCategorieForMovie(MovieId, CatIds);
        }

        public bool IsExisteMovieById(int id)
        {
            return (_db.Movies.Any(c => c.MovieId == id));
        }

        public bool IsExisteSessionById(int id)
        {
            return _db.Seasons.Any(c => c.SeasonId == id);
        }

        public bool IsExisteEpisodeById(int id)
        {
            return (_db.Episodes.Any(c => c.EpisodeId == id));
        }

        public bool IsExisteLinkById(int id)
        {
            return (_db.Links.Any(c => c.LinkId == id));
        }

        public List<ListOfMovieForSlide> ListOfMovieForCreateingSlide()
        {
            return (_db.Movies.Select(c => new ListOfMovieForSlide
            {
                MovieId =PasswordHelper.EncodePasswordToBase64( c.MovieId.ToString()),
                Title = c.Title,
            }).ToList());
        }
    }
}
