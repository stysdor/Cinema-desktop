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
using static CinemaWpf.Model.RowSeat;

namespace CinemaWpf.Controllers
{
    /// <summary>
    /// This class is responsible for delegate request to ReservationService from Infrustructure Layer .
    /// </summary>
    public class ReservationController
    {
        private IReservationService _reservationService;
        private ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of ReservatonController class.
        /// </summary>
        public ReservationController()
        {
            _reservationService = new ReservationService(AutoMapperConfig.Initialize());
            _customerService = new CustomerService(AutoMapperConfig.Initialize());
        }

        /// <summary>
        /// Gets list of Customer - Reservation data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<CustomerReservation> GetReservations()
        {
            var reservationsDto = _reservationService.GetAll();
            var model = new ObservableCollection<CustomerReservation>();
            foreach (ReservationDto reservation in reservationsDto)
            {
                int id = reservation.CustomerId;
                var customer = _customerService.Get(id);
                model.Add(new CustomerReservation()
                {
                    Reservation = new Reservation()
                    {
                        Id = reservation.Id,
                        Status = reservation.Status,
                        CustomerId = id,
                        RowSeatId = reservation.RowSeatId,
                        ShowingId = reservation.ShowingId
                    },
                    Customer = new Customer()
                    {
                        CustomerName = customer.CustomerName,
                        CustomerSurname = customer.CustomerSurname,
                        Email = customer.Email,
                        Phone = customer.Phone
                    }
                }); 
            }
            return model;
        }

        /// <summary>
        /// Gets list of seats for the showing with information of reserved and sold seats.
        /// </summary>
        /// <param name="id">is the id of the showing.</param>
        /// <returns></returns>
        public ObservableCollection<RowSeat> GetSeats(int id)
        {
            var seatsDto = _reservationService.GetSeats(id);
            var seats = new ObservableCollection<RowSeat>();
            foreach (RowSeatDto seat in seatsDto)
            {
                seats.Add(new RowSeat()
                {
                    Id = seat.Id,
                    RowNumber = seat.RowNumber,
                    SeatNumber = seat.SeatNumber,
                    SeatStatus = (Status)seat.SeatStatus
                });
            }
            return seats;
        }

        /// <summary>
        /// Adds the reservation.
        /// </summary>
        /// <param name="model">CustomerReservation model from ViewModel in which are customer and reservation to save.</param>
        /// <returns>Returns true if command succeed.</returns>
        public bool Post(CustomerReservation model)
        {
            var customer = _customerService.GetOrAddByData( new CustomerDto()
            {
                CustomerName = model.Customer.CustomerName,
                CustomerSurname = model.Customer.CustomerSurname,
                Email = model.Customer.Email,
                Phone = model.Customer.Phone
            });

            var result = _reservationService.InsertOrUpdate( new ReservationDto()
            {
                ShowingId = model.Reservation.ShowingId,
                RowSeatId = model.Reservation.RowSeatId,
                CustomerId = customer.Id,
                Status = 0,
            });

            return result > 0 ? true : false;
        }

        /// <summary>
        /// Deletes the reservation.
        /// </summary>
        /// <param name="model">ith information which reservation shoud be removed.</param>
        public void Delete(CustomerReservation model)
        {
            _reservationService.Remove(model.Reservation.Id);
        }

        /// <summary>
        /// Confirms the reservation. Changes status from '0' to '1'.
        /// </summary>
        /// <param name="model">with information which reservation should be confirmed.</param>
        /// <returns>Returns true if command succeed.</returns>
        public bool Confirm(CustomerReservation model)
        {
            var result = _reservationService.InsertOrUpdate(new ReservationDto()
            {
                Id = model.Reservation.Id,
                CustomerId = model.Reservation.CustomerId,
                Status = 1,
                RowSeatId = model.Reservation.RowSeatId,
                ShowingId = model.Reservation.ShowingId
            });

            return result > 0 ? true : false;
        }
    }
}
