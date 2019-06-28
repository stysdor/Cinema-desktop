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
    /// Class delegates actions to showing service.
    /// </summary>
    public class ShowingController
    {
        private IShowingService _showingService;

        /// <summary>
        /// Initializes an instance of ShowingController.
        /// </summary>
        public ShowingController()
        {
            _showingService = new ShowingService(AutoMapperConfig.Initialize());
        }

        /// <summary>
        /// Gets list of all showings.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Showing> GetShowings()
        {
            var data = _showingService.GetAll();
            var list = new ObservableCollection<Showing>();
            foreach (ShowingDto show in data)
            {
                list.Add(new Showing()
                {
                    Id = show.Id,
                    MovieId = show.MovieId,
                    MovieTitle = show.MovieTitle,
                    TheatreId = show.TheatreId,
                    ShowingDateTime = show.ShowingDateTime
                });
            }
            return list;
        }

        /// <summary>
        /// Gets list of actuall showings.
        /// </summary>
        /// <param name="n">n is a number of the nearest showings.</param>
        /// <returns></returns>
        public ObservableCollection<Showing> GetActuall(int n)
        {
            var data = _showingService.GetActuall(n);
            var list = new ObservableCollection<Showing>();
            foreach (ShowingDto show in data)
            {
                list.Add(new Showing()
                {
                    Id = show.Id,
                    MovieId = show.MovieId,
                    MovieTitle = show.MovieTitle,
                    TheatreId = show.TheatreId,
                    ShowingDateTime = show.ShowingDateTime
                });
            }
            return list;
        }

        /// <summary>
        /// Adds or updates the showing.
        /// </summary>
        /// <param name="show"></param>
        /// <returns>Returns true if command succeed.</returns>
        public bool Post(Showing show)
        {
            var id = _showingService.InsertOrUpdate(new ShowingDto()
            {
                Id = show.Id,
                MovieId = show.MovieId,
                MovieTitle = show.MovieTitle,
                TheatreId = show.TheatreId,
                ShowingDateTime = show.ShowingDateTime
            });

            if (id > 0)
                return true;
            else
                return false; ;
        }

        /// <summary>
        /// Deletes the showing.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Showing model)
        {
            _showingService.Remove(model.Id);
        }
    }
}

