using NamaShow.Core.VeiwModels;
using NamaShow.Core.VeiwModels.Landing;
using NamaShow.Core.VeiwModels.Movie.MovieLink;
using NamaShow.Core.VeiwModels.Movie.Session;
using NamaShow.Core.VeiwModels.Movie.Session.Episode;
using NamaShow.Core.VeiwModels.Movie.Session.Episode.SLink;
using NamaShow.Core.VeiwModels.MovieForAdminVM;
using NamaShow.DataLayer.Entities;
using NamaShow.DataLayer.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.Services.InterFaces
{
    public interface IMovieService
    {
        List<Movie> GetListOfMovie(int page);
        Movie GetMovieById(int id);
        Movie GetFullDataOfMovieById(int id);
        void AddMovie(Movie movie);
        bool IsExistMovie(string title);
        void UpdateMovie(Movie movie);
        int UpdateMovieByAdmin(EditMovieByAdmin model);
        void DeleteMovie(int id);
        int AddMovieByAdmin(CreateMovieByAdmin model);
        List<IndexMovieForAdmin> IndexOfMovieForAdmin(int page);
        List<IndexMovieForAdmin> IndexCollectionForAdmin(int id);
        EditMovieByAdmin GetMovieForEditByAdmin(int id);
        bool IsExisteMovieById(int id);
        List<ListOfMovieForSlide> ListOfMovieForCreateingSlide();

        #region Season
        void AddSeason(CreateSessionForAdmin season);
        void UpdateSeason(Season season);
        List<Season> ListOfSeason(int SerialId);
        List<IndexOfSessionForAdmin> IndexOfSessionForAdmin(int MovieId);
        Season GetFullDataOfSeason(int id);
        void ShowSeason(int id);
        void DeleteSeason(int id);
        Season GetSeasonById(int id);
        bool IsExisteSessionById(int id);

        #endregion

        #region Episode
        Episode GetEpisodeById(int id);
        void UpdateEpisode(Episode episode);
        void AddEpisode(Episode episode);
        List<IndexEpisodeForAdmin> IndexEpisodeForAdmin(int sessionId);
        void CreateEpisodeForAdmin(CreateEpisodeForAdmin model);
        void EditEpisodeForAdmin(EditEpisodeForAdmin model);
        bool IsExisteEpisodeById(int id);
        EditEpisodeForAdmin GetEpisodeForEdit(int id);

        void DeleteEpisode(int id);

        #endregion

        #region Comment
        void AddCommentForMovie(Comment comment);
        Comment GetCommentById(int id);
        void ShowComment(int id);
        void ReadedComment(int id);
        List<Comment> GetCommentsOfMovie(int MovieId);
        void UpdateComment(Comment comment);


        #region CommentLike
        void AddCommentLike(CommentLike commentLike);
        List<CommentLike> GetLikesOfComment(int commentId);

        #endregion


        #endregion

        #region Link
        void AddLinkForMovie(Link link);
        void ToggleShowlLink(int id);
        Link GetLinkById(int id);
        void UpdateLink(Link link);
        void DeleteLink(int id);
        EditSLinkForAdmin GetSerialLinkForEdit(int id);
        List<IndexSLinkForAdmin> IndexSerialLinkForAdmin(int EpisodId);
        void CreateSerialLinkForAdmin(CreateSLinkForAdmin model);
        void EditSerialLinkForAdmin(EditSLinkForAdmin model);
        bool IsExisteLinkById(int id);



        #endregion

        #region Rate
        void AddRateForMovie(Rate rate);
        List<Rate> GetRatesOfMovie(int MovieId);
        void UpdateRateOfMOvie(Rate rate);
        Rate GetRateById(int id);
        #endregion

        #region MovieLink
        List<MovieLink> GetLinkesOfMovie(int MovieId);
        void AddMovieLinkByAdmin(CreateMovieLinkForAdmin model);
        EditMovieLinkForAdmin GetMovieLinkForAdminById(int id);
        void EditMovieLinkForAdmin(EditMovieLinkForAdmin model);
        void UpdateMovieLink(MovieLink movieLink);
        void DeleteMovieLink(int id);
        MovieLink GetMovieLinkByid(int id);
        List<IndexOfLinkForMovie> GetLinkesOfMovieForAdmin(int id, int page);
        #endregion

        #region Categorie
        void AddCategorieForMovie(int MovieId, List<int> CatIds);
        void updateCategorieForMovie(int MovieId, List<int> CatIds);

        #endregion

        #region Landing
        List<MovieListForLanding> ListOfMovieForLanding(int page);
        #endregion

    }
}
