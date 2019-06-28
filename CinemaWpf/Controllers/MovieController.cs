using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Mappers;
using Cinema.Infrastructure.Services;
using CinemaWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWpf.Controllers
{
    /// <summary>
    /// This class is responsible for delegate request to MovieService from Infrustructure Layer .
    /// </summary>
    public class MovieController
    {
        private IMovieService _movieService;

        /// <summary>
        /// Initialize a new instance of MovieController class.
        /// </summary>
        public MovieController()
        {
            _movieService = new MovieService(AutoMapperConfig.Initialize());
        }

        /// <summary>
        /// Initializes list of movies.
        /// </summary>
        /// <returns>ObservableCollection of all movies.</returns>
        public ObservableCollection<Movie> GetMovies()
        {
            var data = _movieService.GetAll();
            var list = new ObservableCollection<Movie>();
            foreach (MovieDto movieIn in data)
            {
                list.Add(new Movie()
                {
                    CategoryName = movieIn.CategoryName,
                    Country = movieIn.Country,
                    MovieDescription = movieIn.MovieDescription,
                    MovieTitle = movieIn.MovieTitle,
                    Id = movieIn.Id,
                    YearOfProduction = movieIn.YearOfProduction
                });
            }
            return list;
        }

        /// <summary>
        /// Adds or update the movie.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns true if operation succeed.</returns>
        public bool Post(Movie model)
        {
            {
                MovieDto movie = new MovieDto()
                {
                    Id = model.Id,
                    MovieTitle = model.MovieTitle,
                    MovieDescription = model.MovieDescription,
                    CategoryName = model.CategoryName,
                    Country = model.Country,
                    YearOfProduction = model.YearOfProduction
                };
                var result = _movieService.InsertOrUpdate(movie);

                return result > 0 ? true : false;
            }
        }

        /// <summary>
        /// Deletes the movie.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Movie model)
        {
            _movieService.Remove(model.Id);
        }
    }
}
